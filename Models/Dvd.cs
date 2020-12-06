using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETD_Lab5.Models
{
    public class Dvd
    {
        public int dvdID { get; set; }

        public string title { get; set; }

        public string director { get; set; }
        
        public string actor { get; set; }

        public string studio { get; set; }

        public int copies { get; set; }

        public int ASIN { get; set; }
    }
}
