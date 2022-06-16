using System;
using System.IO;
using Newtonsoft.Json;

namespace Prototype.Models
{
    public class ImageFile
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public DateTime ModifiedOn { get; set; }

        [JsonIgnore]
        public string Extension { get => Path.GetExtension(Name); }
        public ImageFile()
        {
            ModifiedOn = DateTime.Now;
        }
    }
}
