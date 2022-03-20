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
using Google.Apis.Sheets.v4.Data;
using MinecraftAdvanced.Models;

namespace MinecraftAdvanced
{
    public class GoogleHelper
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicatiomName = "MinecraftAdvanced";
        static readonly string SpreadsheetId = "1bJ2KdMGpcOX2xdDDixwyM2Rr7VmbqJd8JejbfavkHFc";
        static readonly string sheet = "names";
        static SheetsService service;
        public GoogleHelper()
        {
            GoogleCredential credential;
            var assembly = Assembly.GetExecutingAssembly();
            string path = @"MinecraftAdvanced.client_secrets.json";

            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicatiomName
            });
        }
        public List<Item> GetItems(string sheetName)
        {
            WebRequest request = WebRequest.Create($"https://opensheet.elk.sh/1bJ2KdMGpcOX2xdDDixwyM2Rr7VmbqJd8JejbfavkHFc/" + sheetName);
            WebResponse response = request.GetResponse();
            string json;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            }
            return JsonConvert.DeserializeObject<List<Item>>(json);
        }
        public void PostFavourite()
        {
            string range = "favourites!A2";
            
            var requestBody = new ValueRange();
            var objectList = new List<object> {111, "fwfw" };

            requestBody.Values = new List<IList<object>> { objectList };

            SpreadsheetsResource.ValuesResource.UpdateRequest request = service.Spreadsheets.Values.Update(requestBody, SpreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            var response = request.Execute();

            Console.WriteLine(JsonConvert.SerializeObject(response));
        }


    }
}
