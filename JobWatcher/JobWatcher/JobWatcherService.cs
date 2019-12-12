using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Threading;
using System.IO;

namespace JobWatcher
{
    public partial class JobWatcherService : ServiceBase
    {
        ILog mLogger;
        Timer mRepeatingTimer;
        double mCounter;
        FileSystemWatcher mFSW;

        public JobWatcherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Job Watcher Windows Service is starting", EventLogEntryType.Information);
            ConfigureLog4Net();

            int i = 0;

            System.Diagnostics.Debugger.Launch();

            do
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Value of i is : {0}", i));
                mLogger.Debug(string.Format("Value of i is: {0}", i));
            } while (i++ < 5);

            mLogger.Error("This is an error.");

            int nTimerDelay = Properties.Settings.Default.TimerDelay;
            mLogger.Debug(string.Format("Value of TimerDelay is: {0}", nTimerDelay));

            mRepeatingTimer = new Timer(myTimerCallback, mRepeatingTimer, nTimerDelay, nTimerDelay);

            try
            {

                mFSW = new FileSystemWatcher(@"C:\Users\HPC\source\repos\JobWatcher\JobWatcher\JobWatcher\bin\Debug\Watch Me");
                mFSW.EnableRaisingEvents = true;
                mFSW.IncludeSubdirectories = true;

                mFSW.Created += MFSW_somethingHappenedToTheFolder;
                mFSW.Changed += MFSW_somethingHappenedToTheFolder;
                mFSW.Deleted += MFSW_somethingHappenedToTheFolder;
                mFSW.Renamed += MFSW_somethingHappenedToTheFolder;

            }
            catch (Exception exc)
            {
                mLogger.Error(exc.ToString());
            }
        }

        private void MFSW_somethingHappenedToTheFolder(object sender, FileSystemEventArgs e)
        {
            mLogger.Debug
                (string.Format("{0} - \r\nFile event for: {1}",
                e.ChangeType, e.FullPath));

            Debug.WriteLine(string.Format("{0} - \r\n File event for: {1}",
                e.ChangeType, e.FullPath));
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Job Watcher Windows Service is stopping", EventLogEntryType.Information);
        }

        private void ConfigureLog4Net()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                mLogger = LogManager.GetLogger("servicelog");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        public void myTimerCallback(object objParam)
        {
            mLogger.Debug(string.Format("Value of counter is: {0}", mCounter++));
            System.Diagnostics.Debug.WriteLine(string.Format("Value of counter is: {0}", mCounter));
        }
    }
}
