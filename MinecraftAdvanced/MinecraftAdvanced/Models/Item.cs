﻿using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace MinecraftAdvanced.Models
{
    public abstract class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("img_src")]
        public string Image { get; set; }
        public UriImageSource ImagePath =>
        new UriImageSource
        {
            Uri = new System.Uri($"{Image}"),
            CachingEnabled = true,
            CacheValidity = System.TimeSpan.FromDays(1)
        };
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("capacity")]
        public int? Capacity { get; set; }
        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }
        [JsonProperty("resources_id")]
        public string Resources { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}