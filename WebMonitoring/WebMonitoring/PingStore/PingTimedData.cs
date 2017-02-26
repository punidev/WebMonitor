using System;
using System.IO;

namespace WebMonitoring.PingStore
{
    public class PingTimedData
    {
        public bool IsAccessible { get; set; }
        public DateTimeOffset MeasurmentTaken { get; set; }
        public double Latency { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{IsAccessible} : [{MeasurmentTaken}] -> {Latency} ms";
        }

        public void Writer()
        {
            string date = $"{MeasurmentTaken:yyyy-MM-dd HH:mm:ss}"
                .Replace(' ', '-')
                .Replace(':', '-');
            using (var sw = new StreamWriter($"C:\\[{Url}]{date}-log.txt"))
            {
                sw.Write($"{MeasurmentTaken:yyyy-MM-dd HH:mm:ss} Url = {Url}, Status : {IsAccessible}");
            }
        }
    }
}
