using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtsIntegrated.Controllers
{
    public class RatingAdd
    {
        public int Value { get; set; }
        public int LocationId { get; set; }

        public string AccountId { get; set; }
        //public string LocationName { get; set; }
    }

public class RatingBase:RatingAdd
    {
        public int RatingId { get; set; }

    }

}