using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BtsIntegrated.Models
{
    public class RecommendLocation
    {
        [Key]
        public int RecommendLocationId { get; set; }

        public int AccountId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public virtual Account Account { get; set; }
    }
}