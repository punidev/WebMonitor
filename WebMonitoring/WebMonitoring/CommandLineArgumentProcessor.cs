using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

namespace WebMonitoring
{
    public static class CommandLineArgumentProcessor
    {
        private static readonly string _pathToInstaller
            = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + "InstallUtil";

        private static readonly string _pathToService
            = Environment.CurrentDirectory + "\\WebMonitoring.exe";

        public static void Run(string[] args)
        {
            var servicesToRun = new ServiceBase[]
            {
                new Service()
            };
            switch (args.FirstOrDefault())
            {
                case "-i":
                    _install();
                    break;
                case "-u":
                    _uninstall();
                    break;
                default:
                    ServiceBase.Run(servicesToRun);
                    break;
            }
        }

        private static void _uninstall()
        {
            Process.Start(_pathToInstaller, "/u " + _pathToService);
        }

        private static void _install()
        {
            Process.Start(_pathToInstaller, _pathToService);
        }
    }
}
