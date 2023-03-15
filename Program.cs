using System;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace ExGoogleDriveApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string spreadsheetId = "1Hpbmpwl704afLj2vhuQ21IReuz42H6fX5SJMHBSZwJ4";
            string range = "시트1!A1:B2";
            string apiKey = "AIzaSyDaWwE-B_Ee_QwFD9Q2QFFDOnRqBXenBxU";

            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = apiKey
            });

            var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();

            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                Console.WriteLine("A1:B2 values:");

                foreach (var row in values)
                {
                    foreach (var cell in row)
                    {
                        Console.Write(cell + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            Console.ReadLine();
        }
    }
}
