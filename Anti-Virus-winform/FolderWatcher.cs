using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anti_Virus_winform
{
    public class FolderWatcher
    {
        public FolderWatcher() { }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File created: {e.FullPath}");
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File deleted: {e.FullPath}");
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File renamed from {e.OldFullPath} to {e.FullPath}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File changed: {e.FullPath}");
        }

        public void watch(string path)
        {
            FileSystemWatcher _watcher = new FileSystemWatcher();
            _watcher.Path = path;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;
            _watcher.Changed += OnChanged;
            _watcher.EnableRaisingEvents = true;
        }
    }
}
