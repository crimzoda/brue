using System.Configuration;
using System.Data;
using System.Windows;

namespace Brue
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "BrueUniqueAppName";

            bool createdNew;
            mutex = new Mutex(true, appName, out createdNew);
            
            if (!createdNew)
            {
                MessageBox.Show("Brue is already running. Check the tray at the bottom right of the screen!", "Brue", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
                return;
            }

            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mutex  != null)
            {
                mutex.ReleaseMutex();
            }
            base.OnExit(e);
        }
    }

}
