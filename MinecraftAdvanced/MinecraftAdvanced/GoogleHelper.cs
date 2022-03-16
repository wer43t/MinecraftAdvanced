using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace MinecraftAdvanced
{
    public class GoogleHelper
    {
        public GoogleHelper()
        {
            
        }
        public List<Building> GetBuildings()
        {
            WebRequest request = WebRequest.Create("https://opensheet.elk.sh/1bJ2KdMGpcOX2xdDDixwyM2Rr7VmbqJd8JejbfavkHFc/buildings_catalog");
            WebResponse response = request.GetResponse();
            string json;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            }
            var buildings = JsonConvert.DeserializeObject<List<Building>>(json);
            return buildings;
        }
    }
}
