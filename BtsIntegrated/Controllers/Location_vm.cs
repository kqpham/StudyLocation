using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BtsIntegrated.Models;

namespace BtsIntegrated.Controllers
{

    public class LocationAdd
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
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
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class LocationBase : LocationAdd
    {
        public int LocationId { get; set; }
    }

    public class LocationWithTimings : LocationBase
    {
        //public LocationWithTimings()
        //{
        //   // Timing = new Timing();
        //}
        //public Timing Timing { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingMondayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingMondayClosingTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingTuesdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingTuesdayClosingTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingWednesdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingWednesdayClosingTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingThursdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingThursdayClosingTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingFridayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingFridayClosingTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingSaturdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingSaturdayClosingTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingSundayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TimingSundayClosingTime { get; set; }
    }

    public class UserLocation
    {
        [Required]
        public string PostalCode { get; set; }
    }

    public class UserGeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class UserGeoWithLocations : UserGeoLocation
    {
        public UserGeoWithLocations()
        {
            Locations = new List<LocationBase>();
        }

        public IEnumerable<LocationBase> Locations;
    }

    public class LocationDetailWithComment:LocationWithTimings
    {
        public LocationDetailWithComment()
        {
            Comments = new List<CommentBase>();
        }

        //public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<CommentBase> Comments { get; set; }
        
    }
}