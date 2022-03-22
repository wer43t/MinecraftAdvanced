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
            try
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
            catch
            {
                return new List<Item>();
            }
        }
        public void PostFavourite(FavouriteItem FI)
        {
            string range = $"favourites!A{GetFavourites().Count + 2}";
            
            var requestBody = new ValueRange();
            var objectList = new List<object> {FI.Id, FI.userLogin, FI.Image, FI.Path, FI.Title, FI.Description, FI.DownloadUrl };

            requestBody.Values = new List<IList<object>> { objectList };

            SpreadsheetsResource.ValuesResource.UpdateRequest request = service.Spreadsheets.Values.Update(requestBody, SpreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            var response = request.Execute();
        }
        public List<FavouriteItem> GetFavourites()
        {
            try
            {
                var result = new List<FavouriteItem>();

                var range = "favourites!A2:G";
                var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();

                var values = response.Values;

                foreach (var value in values)
                {
                    result.Add(new FavouriteItem
                    {
                        Id = Convert.ToInt32(value[0]),
                        userLogin = (string)value[1],
                        Image = (string)value[2],
                        Path = (string)value[3],
                        Title = (string)value[4],
                        Description = (string)value[5],
                        DownloadUrl = (string)value[6],
                    });
                }


                return result;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                return new List<FavouriteItem>();
            }
        }
        public void DeleteFavourite(FavouriteItem FI)
        {
            var favourites = GetFavourites();

            string range = $"favourites!A{favourites.IndexOf(favourites.Find(x => x.Id == FI.Id)) + 2}";

            var requestBody = new ValueRange();
            var objectList = new List<object> { "", "", "", "", "", "", ""};

            requestBody.Values = new List<IList<object>> { objectList };
            SpreadsheetsResource.ValuesResource.UpdateRequest request = service.Spreadsheets.Values.Update(requestBody, SpreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }
    }
}
