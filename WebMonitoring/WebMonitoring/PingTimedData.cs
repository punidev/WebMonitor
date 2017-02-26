using System;
using System.Collections.Generic;
using System.IO;

namespace WebMonitoring
{
    class PingTimedData
    {
        public static List<PingTimedData> Items = new List<PingTimedData>();
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
