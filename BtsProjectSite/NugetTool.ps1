param(
    [ValidateNotNullOrEmpty()]
    [ValidateSet('Run','Copy')]
    [string]$Command = "Run", # run or copy
    [string]$Package = "",
    [string]$Tool = "" # Using "" or "_" will find an exe or ps1 named as the package
)

Function FindToolInFolder([string]$folder, [string]$packageName, [string]$tool) {
    if (!(Test-Path $folder)) {
        return
    }
    if ($tool) {
        $toolPath = Join-Path $folder $tool -resolve -ErrorAction SilentlyContinue
        if ($toolPath -and (Test-Path $toolPath -PathType Leaf)) {
            return $toolPath
        }
    } else {
        # find using packageName
        $toolPath = Join-Path $folder $packageName".ps1" -resolve -ErrorAction SilentlyContinue
        if ($toolPath -and (Test-Path $toolPath -PathType Leaf)) {
            return $toolPath
        }
        $toolPath = Join-Path $folder $packageName".exe" -resolve -ErrorAction SilentlyContinue
        if ($toolPath -and (Test-Path $toolPath -PathType Leaf)) {
            return $toolPath
        }
    }
}

Function FindPackageFolder([string]$packageName) {
    $container = Resolve-Path "."
    
    # find in packages folder
    while (!(Test-Path(Join-Path $container "packages"))) {
        $containerParent = Join-Path $container ".." -resolve
        if ($container -eq $containerParent) {
            Throw "packages folder not found"
        }
        $container = $containerParent
    }
    $container = Join-Path $container "packages"
    $packagePath = (Get-ChildItem -Path $container -Filter "$packageName.*" | Select-Object -First 1).FullName
    if (!$packagePath) {
        Throw "Package not found: $packageName"
    }
    return Join-Path $packagePath "tools"
}

Function FindPackageTool([string]$packageName, [string]$tool) {
    $container = Resolve-Path "."
    
    $toolPath = FindToolInFolder $container $packageName $tool
    if ($toolPath) {
        return $toolPath
    }
    $toolPath = FindToolInFolder (Join-Path $container bin -ErrorAction SilentlyContinue) $packageName $tool
    if ($toolPath) {
        # tool found on bin folder (works for websites)
        return $toolPath
    }
    $toolPath = FindToolInFolder (Join-Path $container tools -ErrorAction SilentlyContinue) $packageName $tool
    if ($toolPath) {
        return $toolPath
    }
    $toolPath = FindToolInFolder (Join-Path $container $packageName\tools -ErrorAction SilentlyContinue) $packageName $tool
    if ($toolPath) {
        return $toolPath
    }
    
    # find in packages folder
    $packageToolsPath = FindPackageFolder $packageName
    $toolPath = FindToolInFolder $packageToolsPath $packageName $tool
    if ($toolPath) {
        return $toolPath
    }
    Throw "Unable to find tool: $tool, package: $packageName"
}

if (!$Package) {
    Throw "Package name is required"
}
if ($Tool -eq "_") {
    $Tool = ""
}


if ($Command.ToLowerInvariant() -eq "copy") {

    # Copy package tools folder
    $CopyTo = "."
    if (@($args).Length -gt 0) {
        $CopyTo = @($args)[0]
    }
    $packageToolsPath = FindPackageFolder $Package
    $targetPackageFolder = Join-Path $CopyTo $Package
    if (Test-Path -PathType Container $targetPackageFolder) {
        Remove-Item $targetPackageFolder -Force -Recurse
    }
    New-Item -path $targetPackageFolder -type directory -Force | Out-Null
    Copy-Item $packageToolsPath $targetPackageFolder -recurse | Out-Null
    "Copied $Package tools to $targetPackageFolder\tools"
} elseif ($Command.ToLowerInvariant() -eq "run") {

    # Run Tool
    $arguments = $args | %{ @($_) -join ", " }
    $expression = (FindPackageTool $Package $Tool) + " " + $arguments
    "$expression"
    Invoke-Expression $expression

} else {
    Throw "Command $Command not found."
}