using System;
using Quartz;
using Quartz.Impl;
namespace WebMonitoring
{
    class CronTab
    {
        public static void Start<T>(Action<SimpleScheduleBuilder> func, bool isCurrentDate = false) 
            where T : IJob
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<T>().Build();
            DateTime localTime = new DateTime(2017, 02, 26, 22, 15, 00);
            ITrigger trigger;
            if (isCurrentDate)
            {
                trigger = TriggerBuilder.Create() 
                .WithIdentity("trigger1", "group1") 
                .StartNow()
                .WithSimpleSchedule(func)
                .StartAt(new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime)))
                .Build();
            }
            else
            {
                trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(func)
                .Build();
            }
            scheduler.ScheduleJob(job, trigger); 
        }
    }
}
