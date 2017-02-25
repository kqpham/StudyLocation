using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BtsProjectSite.Models
{
    public class AccountDetails
    {
        public AccountDetails()
        {
            Ratings = new List<Rating>();
            Comments = new HashSet<Comment>();
            UserHistory = new List<History>();
            Recommendations = new List<RecommendLocation>();
        }

        [Key]
        public int AccountId { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string ClaimsFirstName { get; set; }
        public string ClaimsLastName { get; set; }
        [Display(Name = "Email address")]
        public string ClaimsEmail { get; set; }
        [Display(Name = "Roles")]
        public string ClaimsRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
"CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Rating> Ratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
"CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
"CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<History> UserHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
"CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<RecommendLocation> Recommendations { get; set; }
    }
}