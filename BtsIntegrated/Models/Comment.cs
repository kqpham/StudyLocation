using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BtsIntegrated.Models
{
    [Table("Comment")]
    public class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {

        }

        public int CommentId { get; set; }

        public int LocationId { get; set; }

        public string UserName { get; set; }

        [StringLength(250)]
        public string CommentLines { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Comment> Commentlines { get; set; }

        public virtual Location Location { get; set; }

        public virtual Account Account { get; set; }
    }
}