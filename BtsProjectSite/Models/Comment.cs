using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BtsProjectSite.Models
{
    [Table("Comment")]
    public class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {

        }
        [Key]
        public int CommentId { get; set; }

        public int LocationId { get; set; }

        public int AccountId { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Comment> Comment { get; set; }

        public virtual Location Location { get; set; }

        public virtual  AccountDetails Account { get; set; }
    }
}