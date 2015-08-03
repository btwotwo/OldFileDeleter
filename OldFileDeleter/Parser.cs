using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OldFileDeleter
{

    class Parser
    {
        private IEnumerable<FileInfo> GetFileList (string path)
        {
            IEnumerable<FileInfo> filesArray = null;
            var directory = new DirectoryInfo(path);

            filesArray = directory.GetFiles();
            return filesArray;
        }

        private IEnumerable<DirectoryInfo> GetDirectoriesList(string path)
        {
            IEnumerable<DirectoryInfo> directoryArray = null;
            var directory = new DirectoryInfo(path);
            directoryArray = directory.GetDirectories();
            return directoryArray;
        } 

        public List<FileInfo> GetOldFiles(string path, int lastAccess)
        {
            var files = GetFileList(path);
            
            List<FileInfo> oldFiles = files.Where(file => (DateTime.Now - file.LastAccessTime).Days > lastAccess).ToList();
            return oldFiles;
        }

        public List<DirectoryInfo> GetOldDirectories(string path, int lastAccess)
        {
            var directories = GetDirectoriesList(path);
            
            var oldDirs = (directories.Where(directory => (DateTime.Now - directory.LastAccessTime).Days > lastAccess).ToList());
            return oldDirs;

        }
    }
}
