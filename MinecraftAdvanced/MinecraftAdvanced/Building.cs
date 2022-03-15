﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinecraftAdvanced
{
    public class Building
    {
        [JsonProperty("build_id")]
        public int Id { get; set; }
        [JsonProperty("build_type")]
        public string Type { get; set; }
        [JsonProperty("img_src")]
        public string Image { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("short_description")]
        public string Description { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            return Id == (obj as Building).Id;
        }
    }
}