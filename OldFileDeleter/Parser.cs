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
            FileInfo[] filesArray = null;
            var directory = new DirectoryInfo(path);

            filesArray = directory.GetFiles();
            return filesArray;
        }

        public List<FileInfo> GetOldFiles(string path, int lastAccess)
        {
            var files = GetFileList(path);

            return files.Where(file => (DateTime.Now - file.LastAccessTime).Days > lastAccess).ToList();
        }
    }
}
