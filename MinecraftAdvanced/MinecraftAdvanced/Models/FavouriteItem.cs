using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinecraftAdvanced.Models
{
    public class FavouriteItem : Item
    {
        [JsonProperty("user")]
        public string userLogin { get; set; }
        public FavouriteItem() { }
        public FavouriteItem(Item item)
        {
            Id = item.Id;
            Type = item.Type;
            Image = item.Image;
            Path = item.Path;
            ShortDescription = item.ShortDescription;
            Title = item.Title;
            Capacity = item.Capacity;
            DownloadUrl = item.DownloadUrl;
            Resources = item.Resources;
            Size = item.Size;
            Description = item.Description;
        }
    }
}
