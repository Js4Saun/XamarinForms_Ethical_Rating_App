using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    class Review
    {
        public Review(int id, int userID, int itemID, string reviewDes, int stars)
        {
            this.id = id;
            this.userID = userID;
            this.itemID = itemID;
            this.reviewDes = reviewDes;
            this.stars = stars;
        }

        public Review()
        {

        }

        public int id { get; set; }
        public int userID { get; set; }
        public int itemID { get; set; }
        public string reviewDes { get; set; }
        public int stars { get; set; }
        
        
    }
}
