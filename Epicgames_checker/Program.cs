using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Epicgames_checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var url = "https://status.epicgames.com/api/v2/summary.json";

            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url).Result; 

            var json = JObject.Parse(response);


            foreach (var component in json["components"])
            {
                if ((string)component["status"]!= "operational")
                {
                    Console.WriteLine("Service: "+ (string)component["name"]+ " is "+ (string)component["status"]);
                }

            }

            client.Dispose();
        }
    }
}
