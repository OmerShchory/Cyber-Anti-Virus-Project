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
        private AVEngine engine;
        public FolderWatcher(AVEngine engine) { 
            this.engine = engine;   
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            FileToScan fts = new FileToScan(e.FullPath, "Reactive scan | Event: File created");
            engine.QueueFileForScan(fts);
            Console.WriteLine(fts.ToString());
            AVFfiles.WriteLog(fts.ToString());
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File deleted: {e.FullPath}");
            AVFfiles.WriteLog("File deleted:" + e.FullPath);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            FileToScan fts = new FileToScan(e.FullPath, "Reactive scan | Event: File renamed");
            engine.QueueFileForScan(fts);
            Console.WriteLine(fts.ToString());
            AVFfiles.WriteLog(fts.ToString());
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileToScan fts = new FileToScan(e.FullPath, "Reactive scan | Event: File changed");
            engine.QueueFileForScan(fts);
            Console.WriteLine(fts.ToString());
            AVFfiles.WriteLog(fts.ToString());
        }

        public void watch(string path)
        {
            FileSystemWatcher _watcher = new FileSystemWatcher();
            _watcher.Path = path;
            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;
            _watcher.Changed += OnChanged;
            _watcher.Filter = "*.txt";
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }
    }
}
