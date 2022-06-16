using System;
using System.ComponentModel;
using Prototype.Models;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Prototype.Models
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemSummary { get; set; }
        public string ItemType { get; set; }

        public string DetailsSummary => $"{ItemName}, {ItemType}, {ItemSummary}";

        public int? ImageFileId { get; set; }
        private ImageFile _ImageFile;

        public ImageFile ImageFile
        {
            get => _ImageFile;

            set => Setter(value, ref _ImageFile, nameof(ImageFile));
        }

        public void Setter<T>(T value, ref T field, string name)
        {
            if (!value.Equals(field))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _ProductReference;
        public string ProductReference
        {
            get => _ProductReference;
            set => Setter(value, ref _ProductReference, nameof(ProductReference));
        }
            
        public Item(int id, string itemname, string itemsummary, string itemtype, ImageFile imagefile)
        {
            Id = id;
            ItemName = itemname;
            ItemSummary = itemsummary;
            ItemType = itemtype;
            ImageFile = imagefile;
        }
        public Item()
        {
        }
    }
}