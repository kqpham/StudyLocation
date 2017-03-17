using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BtsIntegrated.Models;

namespace BtsIntegrated.Controllers
{
    public class TimingAdd
    {
        [Display(Name = "Monday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String MondayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String MondayClosingTime { get; set; }

        [Display(Name = "Tuesday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String TuesdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String TuesdayClosingTime { get; set; }

        [Display(Name = "Wednesday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String WednesdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String WednesdayClosingTime { get; set; }

        [Display(Name = "Thursday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String ThursdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String ThursdayClosingTime { get; set; }

        [Display(Name = "Friday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String FridayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String FridayClosingTime { get; set; }

        [Display(Name = "Saturday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String SaturdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String SaturdayClosingTime { get; set; }

        [Display(Name = "Sunday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String SundayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public String SundayClosingTime { get; set; }
        public Location Location { get; set; }
    }

    public class TimingBase : TimingAdd
    { 
        public int TimingId { get; set; }

    }
}