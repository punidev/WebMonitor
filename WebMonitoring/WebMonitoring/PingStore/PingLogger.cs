using Quartz;

namespace WebMonitoring.PingStore
{
    internal class PingLogger : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new HttPingScheduleItem().Execute(
                context.JobDetail
                .JobDataMap["itemId"]
                .ToString()
            ).Writer();
        }
    }
}
