using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;

namespace Brue
{
    internal class RecentFileTracker
    {
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
