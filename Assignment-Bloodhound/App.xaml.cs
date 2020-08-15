using Microsoft.Toolkit.Uwp.Notifications;
using System.Linq;
using System.Windows;

namespace Assignment_Bloodhound
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            // Register AUMID, COM server, and activator
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<AppNotificationActivator>("Schuetze.AssignmentBloodhound");
            DesktopNotificationManagerCompat.RegisterActivator<AppNotificationActivator>();

            // If launched from a toast
            if (e.Args.Contains("-ToastActivated"))
            {
                // AppNotificationActivator code will run after this completes,
                // and will show a window if necessary.
            }

            else
            {
                // Show the window
                new MainWindow().Show();
            }

            base.OnStartup(e);
        }
    }
}
