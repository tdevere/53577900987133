using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace WpfAppNet6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string userID = "YourUserId";
        string appcenterSecret = "";

        protected override void OnStartup(StartupEventArgs e)
        {
            AppCenter.SetUserId(userID);
            AppCenter.LogLevel = LogLevel.Verbose;

            //https://docs.microsoft.com/en-us/appcenter/sdk/analytics/windows#manage-start-session
            Analytics.EnableManualSessionTracker();

            AppCenter.Start(appcenterSecret, typeof(Analytics));

            //Necessary in 4.5.1? Auto Tracked in previous version?
            Analytics.StartSession();

            Analytics.TrackEvent("App Center OnStartup Complete .NET 6");

            base.OnStartup(e);
        }
    }
}
