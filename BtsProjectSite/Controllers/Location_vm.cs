using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BtsProjectSite.Models;

namespace BtsProjectSite.Controllers
{
    public class LocationAdd
    {
        public LocationAdd()
        {
           // Timings = new List<Timing>();
        }

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

        public Timing Timings { get; set; }
    }

    public class LocationBase : LocationAdd
    {
        public LocationBase()
        {

        }

        [Key]
        public int LocationId { get; set; }
    }

    public class LocationWithTimings : LocationBase
    {
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingMondayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingMondayClosingTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingTuesdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingTuesdayClosingTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingWednesdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingWednesdayClosingTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingThursdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingThursdayClosingTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingFridayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingFridayClosingTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingSaturdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingSaturdayClosingTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingSundayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TimingSundayClosingTime { get; set; }
    }

}