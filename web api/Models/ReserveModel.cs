using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ReserveModel
    {
        public int Sno { get; set; }
        public string Hotel { get; set; }
        public Nullable<System.DateTime> Arrival { get; set; }
        public Nullable<System.DateTime> Departure { get; set; }
        public string Type { get; set; }
        public string Guests { get; set; }
        public Nullable<int> Price { get; set; }

    }
}