using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BtsIntegrated.Models;

namespace BtsIntegrated.Controllers
{
    public class CommentAdd
    {
        public CommentAdd()
        {

        }
        public string CommentLines { get; set; }
    }
    public class CommentBase : CommentAdd
    {
        public CommentBase()
        {

        }
        [Key]
        public int CommentId { get; set; }
    }

    public class CommentWithLocation : CommentBase
    {
        public CommentWithLocation()
        {

        }
        public Location Locations { get; set; }
    }
}