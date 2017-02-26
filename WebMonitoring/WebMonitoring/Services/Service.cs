using System.ServiceProcess;

namespace WebMonitoring.Services
{
    internal partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            CronTab.Start("http://google.com", x => x.WithIntervalInMinutes(2).RepeatForever(), id: 1);
            CronTab.Start("http://apple.com", x => x.WithIntervalInMinutes(5).RepeatForever(), id: 2);
            CronTab.Start("http://microsoft.com", isCurrentDate: true, id: 3);
        }

        protected override void OnStop()
        {
        }
    }
}
