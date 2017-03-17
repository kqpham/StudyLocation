using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BtsIntegrated.Models
{
    public class History
    {

        public History()
        {
            Locations = new List<Location>();
        }
        [Key]
        public int HistoryId { get; set; }

        public int AccountId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
"CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Location> Locations { get; set; }
        public virtual Account Account { get; set; }

    }
}