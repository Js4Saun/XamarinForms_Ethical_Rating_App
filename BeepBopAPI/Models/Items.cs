using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepBopAPI.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemSummary { get; set; }
        
        public string ItemType { get; set; }

        public int? ImageFileId { get; set; }
        public virtual ImageFile ImageFile { get; set; }


    }
    
}
