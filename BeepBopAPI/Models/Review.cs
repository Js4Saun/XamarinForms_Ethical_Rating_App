using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepBopAPI.Models
{
    public class Review
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int itemID { get; set; }
        public string reviewDes { get; set; }
        public int stars { get; set; }
    }
}
