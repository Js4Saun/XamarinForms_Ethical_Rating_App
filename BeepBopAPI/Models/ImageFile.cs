﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BeepBopAPI.Models
{
    public class ImageFile
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public DateTime ModifiedOn { get; set; }

        //public string Extension { get => Path.GetExtension(this.Name); }
        //public ImageFile()
        //{
        //    this.ModifiedOn = DateTime.Now;
        //}
    }
}
