using Microsoft.QueryStringDotNET;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Notifications;

namespace Assignment_Bloodhound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNotification(object sender, RoutedEventArgs e)
        {
            ToastContent content = new ToastContent()
            {
                // Arguments provided to the app when the notification is selected
                Launch = new QueryString()
                {
                    { "action", "null" }
                }.ToString(),

                // Visual component of the notification
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "New Notification Message",
                                HintMaxLines = 1
                            },
                            new AdaptiveText()
                            {
                                Text = "This test will make sure that notifications are working properly."
                            }
                        },

                        Attribution = new ToastGenericAttributionText()
                        {
                            Text = "Via App"
                        }
                    }
                },

                // Actions the user can perform from the notification
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("View Activity", "action=null")
                        {
                            ActivationType = ToastActivationType.Foreground
                        },

                        new ToastButton("Mark As Complete", "action=null")
                        {
                            ActivationType = ToastActivationType.Background
                        }
                    }
                }
            };

            // Create and show the notification
            //ToastNotification toast = new ToastNotification(content.GetXml());
            //DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);

            // Create a scheduled notification
            ScheduledToastNotification toast = new ScheduledToastNotification(content.GetXml(), DateTime.Now.AddSeconds(5));
            DesktopNotificationManagerCompat.CreateToastNotifier().AddToSchedule(toast);
        }

        private void ClearNotifications(object sender, RoutedEventArgs e)
        {
            // Clear all toast notifications
            DesktopNotificationManagerCompat.History.Clear();
        }
    }
}
