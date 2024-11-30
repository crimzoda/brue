using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows;

namespace Brue
{
    internal class RecycleBinMonitor
    {
        private readonly string _shadowDir;
        private readonly string _recoveryDir;
        private readonly FileSystemWatcher _watcher;
        private string _userRecycleBinPath;
        private string _lastFileHash = string.Empty;
        public readonly RecentFileTracker _recentFileTracker;
        private MainWindow _mainWindow;

        private string[] _flagKeywords = [
            "final", "important", "project", "report", "draft", "release", "official", "submission",
        "statement", "contract", "confidential", "review", "data", "restore", "priority", "urgent"];

        public delegate void RecycleBinChangedEventHandler(object sender, EventArgs e);
        public event RecycleBinChangedEventHandler ShadowDirectoryUpdated;

        public RecycleBinMonitor(string shadowDir, string recoveryDir, MainWindow mainWindow)
        {
            _shadowDir = shadowDir;
            _recoveryDir = recoveryDir;
            _mainWindow = mainWindow;
            _userRecycleBinPath = GetCurrentUserRecycleBinPath();
            _watcher = new FileSystemWatcher(_userRecycleBinPath);
            _recentFileTracker = new RecentFileTracker();

            _watcher.Created += OnRecycleBinChanged;
            _watcher.Deleted += OnRecycleBinChanged;

            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;

            _watcher.EnableRaisingEvents = true;
            UpdateShadowCopy();
            CheckDirectory(_recoveryDir, false);
            _recentFileTracker.UpdateRecentFiles();
        }

        private string GetCurrentUserRecycleBinPath()
        {
            string userSid = WindowsIdentity.GetCurrent().User.Value;

            return Path.Combine(@"C:\$Recycle.Bin", userSid);
        }

        private void OnRecycleBinChanged(object sender, FileSystemEventArgs e)
        {
            UpdateShadowCopy();
        }

        public void UpdateShadowCopy()
        {
            try
            {
                CheckDirectory(_shadowDir, true);

                _recentFileTracker.UpdateRecentFiles();

                foreach (string filePath in FileSystem.GetFiles(_userRecycleBinPath))
                {
                    if (Path.GetFileName(filePath).StartsWith("$I"))
                    {
                        string originalName = GetOriginalFileName(filePath);
                        Trace.WriteLine(filePath + ": " + originalName);
                        if (_recentFileTracker.RecentFiles.Contains(originalName) 
                            || _flagKeywords.Any(keyword => originalName.Contains(keyword))
                            || GetFlaggedFileTypes().Any(fileType => Path.GetExtension(originalName) == fileType))
                        {
                            Trace.WriteLine($"Found an important file inside Recycle Bin! {originalName}");
                            if (File.Exists(Path.Combine(_userRecycleBinPath, Path.GetFileName(filePath).Replace("$I", "$R")))
                            && !File.Exists(Path.Combine(_shadowDir, Path.GetFileName(filePath).Replace("$I", "$R"))))
                            {
                                File.Copy(Path.Combine(_userRecycleBinPath, Path.GetFileName(filePath).Replace("$I", "$R")), Path.Combine(_shadowDir, Path.GetFileName(filePath).Replace("$I", "$R")));
                            }
                        }
                    }
                }
                ShadowDirectoryUpdated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating shadow copy: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string[] GetFlaggedFileTypes()
        {
            string flaggedFileTypes = Properties.Settings.Default.flaggedFileTypes;

            string[] fileTypeArray = flaggedFileTypes.Split(',').Select(s => s.Trim()).ToArray();

            return fileTypeArray;
        }

        public void ShowDeletedFiles()
        {
            string[] files = Directory.GetFiles(_shadowDir);
            if (files.Length > 0)
            {
                //Do nothing
            }
        }

        private void OnRecycleBinDeleted(object sender, FileSystemEventArgs e)
        {
            if (IsRecycleBinEmpty())
            {
                List<String> file_list = new List<String>();

                foreach (string filePath in FileSystem.GetFiles(_shadowDir))
                {
                    string fileName = Path.GetFileName(filePath);

                    if (fileName.StartsWith("$R"))
                    {
                        file_list.Add(filePath);
                    }
                }

                string currentHash = ComputeHash(file_list);

                if (currentHash == _lastFileHash)
                {
                    return;
                }

                _lastFileHash = currentHash;

                List<string> meta_files = new List<string>();

                foreach (string filePath in file_list)
                {
                    meta_files.Add(GetOriginalFileName(filePath));
                }



            }
        }

        public string GetOriginalFileName(string iFilePath)
        {
            try
            {
                iFilePath = Path.Combine(_userRecycleBinPath, Path.GetFileName(iFilePath).Replace("$R", "$I"));

                if (!File.Exists(iFilePath))
                {
                    Trace.WriteLine($"File not found: {iFilePath}");
                    return string.Empty;
                }

                using (FileStream fs = new FileStream(iFilePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);

                    const int headerSize = 24;
                    int fileNameLength = 0;

                    if (bytes.Length >= headerSize + 4)
                    {
                        fileNameLength = BitConverter.ToInt32(bytes, headerSize);
                    }

                    if (fileNameLength > 0 && bytes.Length >= headerSize + 4 + (fileNameLength * 2))
                    {
                        byte[] nameBytes = new byte[fileNameLength * 2];
                        Array.Copy(bytes, headerSize + 4, nameBytes, 0, fileNameLength * 2);
                        return Encoding.Unicode.GetString(nameBytes).TrimEnd('\0');
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error reading {iFilePath}: {ex.Message}");
                return string.Empty;
            }
        }

        private string ComputeHash(List<string> file_list)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string combinePaths = string.Join(',', file_list.OrderBy(path => path));
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinePaths));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool IsRecycleBinEmpty()
        {
            int i = 0;
            foreach (string filePath in FileSystem.GetFiles(_userRecycleBinPath))
            {
                string fileName = Path.GetFileName(filePath);
                if (!fileName.StartsWith("$I") && !fileName.StartsWith("$R") && fileName != "desktop.ini")
                {
                    i++;
                }
            }
            if (i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void CheckDirectory(string path, bool deleteDir)
        {
            if (Directory.Exists(path))
            {
                // Clear the existing shadow copy
                //if (deleteDir)
                //{
                //    Directory.Delete(path, true);
                //}
                //Directory.CreateDirectory(path);
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

    }
}
