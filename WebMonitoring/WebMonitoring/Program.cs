using System;
using System.Diagnostics;
using System.Net.Http;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace WebMonitoring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var baseAddress = "http://localhost:8080/";
            WebApp.Start<Startup>(baseAddress);
            HttpClient client = new HttpClient();

            var headers = client.GetAsync($"{baseAddress}/api/status/Headers").Result;
            Console.WriteLine(headers);
            Console.WriteLine(headers.Content.ReadAsStringAsync().Result);

            var response = client.GetAsync($"{baseAddress}/api/status/CheckStatus?code={headers.StatusCode}").Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
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
