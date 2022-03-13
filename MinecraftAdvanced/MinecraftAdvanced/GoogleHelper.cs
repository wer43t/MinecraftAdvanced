using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

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
        public List<string> ReadNames()
        {
            var range = $"{sheet}!B2:B";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;
            var result = new List<string>();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    result.Add(row[0].ToString());
                }
            }
            return result;
        }

    }
}
