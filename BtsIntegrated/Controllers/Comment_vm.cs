using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BtsIntegrated.Models;
using System.Web.Mvc;

namespace BtsIntegrated.Controllers
{
    public class CommentAdd
    {
        public CommentAdd()
        {

        }
        [HiddenInput]
        public int AccountId { get; set; }
        [HiddenInput]
        public int LocationId { get; set; }
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

    public class CommentEditForm
    {
        public int AccountId { get; set; }
        public int LocationId { get; set; }
        public int CommentId { get; set; }
        public string CommentLines { get; set; }
    }
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public string CommentLines { get; set; }
    }
}