using System;
using Quartz;
using Quartz.Impl;
using WebMonitoring.PingStore;

namespace WebMonitoring.Services
{
    public class CronTab
    {
        public static void Start(
            string itemId,
            Action<SimpleScheduleBuilder> func, 
            bool isCurrentDate = false,
            int id = 0)
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<PingLogger>().UsingJobData("itemId", itemId).Build();

            ITrigger trigger;
            if (isCurrentDate)
            {
                trigger = TriggerBuilder.Create() 
                .WithIdentity(string.Concat("trigger_", id), "group1")
                .WithCronSchedule("0 15 22 ? * */2 *")
                .Build();
            }
            else
            {
                trigger = TriggerBuilder.Create()
                .WithIdentity(string.Concat("trigger_", id), "group1")
                .StartNow()
                .WithSimpleSchedule(func)
                .Build();
            }
            scheduler.ScheduleJob(job, trigger); 
        }
    }
}
