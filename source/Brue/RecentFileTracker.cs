using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;

namespace Brue
{
    internal class RecentFileTracker
    {
        // Function: To keep track of files within the 'Recent' file directory

        public List<string> RecentFiles { get; set; }

        public RecentFileTracker()
        {
            string recentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            Trace.WriteLine($"Recent Folder Path: {recentFolder}");
            RecentFiles = new List<string>();

        }

        public void UpdateRecentFiles()
        {
            List<string> newRecentFiles = new List<string>();

            foreach (string lnkFile in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Recent), "*.lnk"))
            {
                // Once the original directory for .lnk files are retrieved and are verified as valid, they are added to the list of recent files.
                string resolvedPath = ResolveShortcut(lnkFile);
                if (!string.IsNullOrEmpty(resolvedPath) && !Path.GetFileName(resolvedPath).StartsWith("$"))
                {
                    newRecentFiles.Add(resolvedPath);
                }
            }

            HashSet<string> files = new HashSet<string>(RecentFiles);
            files.UnionWith(newRecentFiles);
            RecentFiles = files.ToList();
        }

        static string ResolveShortcut(string lnkFilePath)
        {
            // Retrieve the original directory for .lnk shortcut files...
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(lnkFilePath);
                return shortcut.TargetPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resolving shortcut {lnkFilePath}: {ex.Message}");
                return null;
            }
        }
    }
}
