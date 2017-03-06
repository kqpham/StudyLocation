﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BtsProjectSite.Controllers
{
    public class CommentAdd
    {
        public CommentAdd()
        {

        }
        public string CommentLines { get; set; }
    }
    public class CommentBase: CommentAdd
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
            locations = new List<LocationBase>();
        }
        public int Id { get; set; }
        public IEnumerable<LocationBase> locations { get; set; }
    }

    /*public class LocationEditComments
    {
        public LocationEditComments()
        {
            LocationIds = new List<int>();
        }
        public int Id { get; set; }
        public IEnumerable<int> LocationIds { get; set; }
    }*/
}