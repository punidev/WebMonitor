using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using WebMonitoring.RouteData;
using WebMonitoring.Services;

namespace WebMonitoring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var baseAddress = "http://localhost:8080/";
            WebApp.Start<Startup>(baseAddress);
            HttpClient client = new HttpClient();

            var headers = client.GetAsync($"{baseAddress}/api/status/CheckStatus").Result;
            Console.WriteLine(headers);
            Console.WriteLine(headers.Content.ReadAsStringAsync().Result);
            try
            {
                CommandLineArgumentProcessor.Run(args);
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
