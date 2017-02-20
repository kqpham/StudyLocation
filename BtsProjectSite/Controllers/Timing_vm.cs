﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BtsProjectSite.Models;

namespace BtsProjectSite.Controllers
{
    public class TimingAdd
    {

        [Display(Name = "Monday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? MondayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? MondayClosingTime { get; set; }

        [Display(Name = "Tuesday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TuesdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? TuesdayClosingTime { get; set; }

        [Display(Name = "Wednesday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? WednesdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? WednesdayClosingTime { get; set; }

        [Display(Name = "Thursday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? ThursdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? ThursdayClosingTime { get; set; }

        [Display(Name = "Friday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? FridayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? FridayClosingTime { get; set; }

        [Display(Name = "Saturday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? SaturdayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? SaturdayClosingTime { get; set; }

        [Display(Name = "Sunday")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? SundayOpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime? SundayClosingTime { get; set; }
        public virtual Location Location { get; set; }
    }

    public class TimingBase : TimingAdd
    {
        public TimingBase()
        { }

        [Key]
        public int TimingId { get; set; }

    }
}