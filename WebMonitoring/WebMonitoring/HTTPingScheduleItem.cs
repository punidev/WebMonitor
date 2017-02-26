using System;
using System.Diagnostics;
using System.Net;

namespace WebMonitoring
{
    internal class HttPingScheduleItem
    {
        public PingTimedData Execute(string url)
        {
            try
            {
                var ping = WebRequest.Create(url);
                var sw = Stopwatch.StartNew();
                ping.Timeout = 8000;
                using (var response =  ping.GetResponse())
                {
                    sw.Stop();
                    Console.WriteLine($"Pinging {url}");
                    Console.WriteLine("Done {0}", ((HttpWebResponse)response).StatusCode);
                    var elapsed = (double)sw.ElapsedTicks / Stopwatch.Frequency;
                    return new PingTimedData
                    {
                        IsAccessible = ((HttpWebResponse)response).StatusCode == HttpStatusCode.OK,
                        MeasurmentTaken = DateTimeOffset.Now,
                        Latency = elapsed,
                        Url = url.Replace("http://" , "www.")
                                 .Replace("https://", "www.")
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new PingTimedData
                {
                    IsAccessible = false,
                    MeasurmentTaken = DateTimeOffset.Now,
                    Latency = 0,
                    Url = "error"
                };
            }
        }
    }
}
