using System;
using System.Collections.Generic;
using System.IO;

namespace OldFileDeleter
{
    class Parser
    {
        private FileInfo[] GetFileList (string path)
        {
            FileInfo[] filesArray = null;
            DirectoryInfo directory = new DirectoryInfo(path);

            filesArray = directory.GetFiles();
            return filesArray;
        }

        public List<FileInfo> GetOldFiles(string path, int lastAccess)
        {
            FileInfo[] files = GetFileList(path);

            var oldFiles = new List<FileInfo>();

            foreach(FileInfo file in files)
            {
                if((DateTime.Now - file.LastAccessTime).Days > lastAccess)
                {
                    oldFiles.Add(file);
                }
            }
            return oldFiles;
        }
    }
}
