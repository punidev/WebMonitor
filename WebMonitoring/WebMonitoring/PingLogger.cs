using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace WebMonitoring
{
    class PingLoggerGoogle : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new HttPingScheduleItem().Execute("http://google.com").Writer();
        }
    }
    class PingLoggerMicrosoft : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new HttPingScheduleItem().Execute("http://microsoft.com").Writer();
        }
    }
    class PingLoggerApple : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new HttPingScheduleItem().Execute("http://apple.com").Writer();
        }
    }
}
