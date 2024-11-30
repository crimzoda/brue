using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Brue
{
    /// <summary>
    /// Interaction logic for FileItem.xaml
    /// </summary>
    public partial class FileItem : UserControl
    {
        public string filePath { get; set; }
        public string binPath { get; set; }
        private MainWindow _mainWindow;

        string[] imageTypes = [".png", ".jpeg", ".jpg", ".mpeg", ".bmp", ".tiff", ".svg", ".webp", ".gif", ".heic"];
        string[] videoTypes = [".mp4", ".mov", ".avi", ".mkv", ".webm", ".flv", ".wmv"];
        string[] audioTypes = [".mp3", ".wav", ".aac", ".ogg", ".flac", ".wma", ".aiff"];

        public FileItem(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbFileName.Text = System.IO.Path.GetFileName(filePath);
            string fileType = System.IO.Path.GetExtension(filePath);
            Trace.WriteLine(fileType);
            if (imageTypes.Any(type => fileType.Contains(type)))
            {
                imgType.Source = new BitmapImage(new Uri("ui/brue_image_file.png", UriKind.Relative));
            }
            else if (videoTypes.Any(type => fileType.Contains(type)))
            {
                imgType.Source = new BitmapImage(new Uri("ui/brue_video_file.png", UriKind.Relative));
            }
            else if (audioTypes.Any(type => fileType.Contains(type)))
            {
                imgType.Source = new BitmapImage(new Uri("ui/brue_audio_file.png", UriKind.Relative));
            }
            else
            {
                imgType.Source = new BitmapImage(new Uri("ui/brue_file.png", UriKind.Relative));
            }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(binPath))
            {
                File.Copy(binPath, GetUniqueFileName("recovery", System.IO.Path.GetFileName(filePath)));
                File.Delete(binPath);
                _mainWindow.UpdateUI();
            }
        }

        private string GetUniqueFileName(string directory, string fileName)
        {
            string filePath = System.IO.Path.Combine(directory, fileName);
            if (!File.Exists(filePath)) return filePath; // Return if the file doesn't exist

            int count = 2; // Start counting from 2
            string newFileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);

            // Increment the count until we find a unique file name
            do
            {
                newFileName = $"{fileNameWithoutExtension} ({count}){fileExtension}";
                filePath = System.IO.Path.Combine(directory, newFileName);
                count++;
            } while (File.Exists(filePath));

            return filePath; // Return the unique file path
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            tbFileName.Visibility = Visibility.Collapsed;
            spFileActions.Visibility = Visibility.Visible;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            spFileActions.Visibility = Visibility.Collapsed;
            tbFileName.Visibility = Visibility.Visible;
            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
            => Process.Start(new ProcessStartInfo(binPath) { UseShellExecute = true });

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(binPath))
            {
                File.Delete(binPath);
                _mainWindow.wpFiles.Children.Remove(this);
                _mainWindow.UpdateUI();
            }
            
        }
    }
}
