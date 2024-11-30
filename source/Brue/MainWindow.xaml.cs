using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Brue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string localVersion = "1.0.0";

        private RecycleBinMonitor _monitor;
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            PositionWindowBottomRight();
            _httpClient = new HttpClient();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckForUpdates();
            string[] directories = CheckBrueDirectory();

            // Create the RecycleBinMonitor
            _monitor = new RecycleBinMonitor(directories[0], directories[1], this);
            _monitor.ShadowDirectoryUpdated += _monitor_ShadowDirectoryUpdated;
            Dispatcher.Invoke(() => UpdateUI());
        }

        private async Task CheckForUpdates()
        {
            try
            {
                string latestVersion = await _httpClient.GetStringAsync("https://raw.githubusercontent.com/crimzoda/brue/main/README.md");
                if (latestVersion.Trim() != localVersion)
                {
                    Process.Start("https://raw.githubusercontent.com/crimzoda/brue/main/brue-installer.exe");
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex) { }
        }

        private string[] CheckBrueDirectory()
        {
            string appdata_dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string brue_data_dir = Path.Combine(appdata_dir, "Brue");
            string shadow_dir = Path.Combine(brue_data_dir, "recycle_bin_shadow");
            string recovery_dir = Path.Combine(brue_data_dir, "recovery");

            if (!Path.Exists(brue_data_dir))
            {
                Directory.CreateDirectory(brue_data_dir);
                Directory.CreateDirectory(shadow_dir);
                Directory.CreateDirectory(recovery_dir);
            }

            return [shadow_dir, recovery_dir];
        }

        private void _monitor_ShadowDirectoryUpdated(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => UpdateUI());
        }

        public void UpdateUI()
        {
            Dispatcher.Invoke(() =>
            {
                // Clear any existing children before adding new ones
                wpFiles.Children.Clear();

                // Make sure the _monitor is not null and has a shadow directory
                if (_monitor != null)
                {
                    // Loop through the files in the shadow directory
                    foreach (string file in FileSystem.GetFiles("recycle_bin_shadow"))
                    {
                        FileItem fileItem = new FileItem(this);

                        // Get the original file path and set it in the FileItem
                        string originalFilePath = _monitor.GetOriginalFileName(System.IO.Path.Combine("recycle_bin_shadow", System.IO.Path.GetFileName(file).Replace("$R", "$I")));
                        fileItem.filePath = originalFilePath;
                        fileItem.binPath = file;
                        // Add the FileItem control to the WrapPanel
                        if (originalFilePath != string.Empty)
                        {
                            wpFiles.Children.Add(fileItem);
                        }
                        else
                        {
                            File.Delete(file);
                        }
                    }
                    if (wpFiles.Children.Count == 0)
                    {
                        wpIdle.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        wpIdle.Visibility = Visibility.Hidden;
                    }
                }
            });
        }

        private void btnFolder_Click(object sender, RoutedEventArgs e)
            => Process.Start("explorer.exe", "recovery");

        private void btnAbout_Click(object sender, RoutedEventArgs e)
            => tcNavigator.SelectedIndex = 2;

        private void btnSettings_Click(object sender, RoutedEventArgs e)
            => tcNavigator.SelectedIndex = 1;

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
            => tcNavigator.SelectedIndex = 0;

        private void tbFlaggedFileTypes_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFlaggedFileTypes.ApplyTemplate();
            
            var placeholder = (TextBlock)tbFlaggedFileTypes.Template.FindName("Placeholder", tbFlaggedFileTypes);
            if (placeholder != null)
            {
                placeholder.Visibility = string.IsNullOrEmpty(tbFlaggedFileTypes.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
            
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.flaggedFileTypes = tbFlaggedFileTypes.Text;
            Properties.Settings.Default.Save();
            _monitor.UpdateShadowCopy();
        }

        private void tbFlaggedFileTypes_Loaded(object sender, RoutedEventArgs e)
            => tbFlaggedFileTypes.Text = Properties.Settings.Default.flaggedFileTypes;

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void trayExit_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }

        private void tbNotifyIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void PositionWindowBottomRight()
        {
            var workingArea = SystemParameters.WorkArea;
            this.Left = workingArea.Right - this.Width;
            this.Top = workingArea.Bottom - this.Height;
        }

        protected override void OnClosed(EventArgs e)
        {
            tbNotifyIcon.Dispose();
            base.OnClosed(e);
        }
    }
}