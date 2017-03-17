using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BtsIntegrated.Models
{

    [Table("Location")]
    public class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            //Timing = new Timing();
            Comments = new HashSet<Comment>();
            Ratings = new List<Rating>();
        }
        public int LocationId { get; set; }

        //[Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        //[Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //[Required]
        public string City { get; set; }

        public bool WifiAvailability { get; set; }

        public bool Outlet { get; set; }

        public bool StudyRoom { get; set; }

        public bool Printers { get; set; }

        public bool Purchase { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool Food { get; set; }

        public bool Washrooms { get; set; }

        public bool HandicapAccess { get; set; }

        public bool AcceptDebit { get; set; }

        public bool AcceptCredit { get; set; }

        public bool CashOnly { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
        //    "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Timing> Timings { get; set; }
        public Timing Timing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
    "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Rating> Ratings { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}