using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BtsIntegrated.Models
{
    [Table("Timing")]
    public class Timing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [ForeignKey("Location")]
        public int TimingId { get; set; }

        [Display(Name = "Monday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string MondayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string MondayClosingTime { get; set; }

        [Display(Name = "Tuesday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TuesdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string TuesdayClosingTime { get; set; }

        [Display(Name = "Wednesday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string WednesdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string WednesdayClosingTime { get; set; }

        [Display(Name = "Thursday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string ThursdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string ThursdayClosingTime { get; set; }

        [Display(Name = "Friday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string FridayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string FridayClosingTime { get; set; }

        [Display(Name = "Saturday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string SaturdayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string SaturdayClosingTime { get; set; }

        [Display(Name = "Sunday")]
        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string SundayOpeningTime { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:MM tt}", ApplyFormatInEditMode = true)]
        public string SundayClosingTime { get; set; }

        [Required]
        public Location Location { get; set; }
    }
}