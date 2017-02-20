#Team03Repo

##Team Members:

Faiq Malik

Kevin Pham

Vincent Wong

Iceal Claveria

Project Details

This project was built using ASP.NET MVC 5.

The environment used to build this project was Visual Studio Enterprise with Update 3.

This project can run on the Community Edition.

In the event that this project has issues running on the community or any other version, then do the following.

Navigate to root directory of the project and go to the the following destination directory.

.vs > config

In the config folder delete the applicationhost.config file.

Open the project and rebuild the solution and it should run.

In the event that it still does not run then do the following:

Right Click the Project name (The project name is the one which DOES NOT have 'Solution in its name') and select properties.
Select the Web tab
press the button 'Create Virtual Directory'
After this step the project should build and run.

If there is an issue where the port is busy and the project will not run because of it then do the followng.

Stop the IIS Express Web server. It is located in the bottom right side where the taskbar icons reside. Right Click it and press Exit which will stop it.
Enter one digit higher in the port number as descibed in the upper section.
Recreate the virtual directory and build.
The project should build and run on Edge, Chrome or Firefox.

If you still have trouble running the project after trying for 10hrs straight then please proceed to have a mental breakdown and throw your computer into the nearest recycling bin.
