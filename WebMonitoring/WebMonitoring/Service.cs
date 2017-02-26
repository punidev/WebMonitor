using System.ServiceProcess;
using System.Threading;

namespace WebMonitoring
{
    partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        private readonly Thread _first =
            new Thread(() => CronTab.Start<PingLoggerGoogle>(
                x => x.WithIntervalInSeconds(15).RepeatForever()
                ));

        private readonly Thread _second =
            new Thread(() => CronTab.Start<PingLoggerMicrosoft>(
                x => x.WithIntervalInMinutes(20).RepeatForever()
                ));

        private readonly Thread _third =
            new Thread(() => CronTab.Start<PingLoggerApple>(
                x => x.WithIntervalInHours(48).RepeatForever(), true
                ));
        protected override void OnStart(string[] args)
        {
            CronTab.Start<PingLoggerGoogle>(
                x => x.WithIntervalInSeconds(15).RepeatForever()
                );
            CronTab.Start<PingLoggerMicrosoft>(
                x => x.WithIntervalInMinutes(20).RepeatForever()
                );
            //_first.Start();
            //_second.Start();
            //_third.Start();
        }

        protected override void OnStop()
        {
            //_first.Abort();
            //_second.Abort();
            //_third.Abort();
        }
    }
}
