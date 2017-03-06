using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtsProjectSite.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        public int LocationId { get; set; }

        public int AccountId { get; set; }

        public int Value { get; set; }


        public virtual Location Location { get; set; }

        public virtual AccountDetails Account{ get; set; }

    }
}