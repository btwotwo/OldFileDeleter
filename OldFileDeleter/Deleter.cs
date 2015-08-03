using System;
using System.Collections.Generic;
using System.IO;

namespace OldFileDeleter
{
    class Deleter
    {
        private bool Confirmator(List<FileInfo> oldFiles, List<DirectoryInfo> oldDirectories )
        {
            if (oldFiles.Count == 0 && oldDirectories.Count == 0)
            {
                Console.WriteLine("You don't have any old files or folders in this directory");
                Console.ReadLine();
                return false;
            }


            else
            {
                foreach (var file in oldFiles)
                {
                    Console.WriteLine(file);
                }
                foreach (var folder in oldDirectories)
                {
                    Console.WriteLine(folder);
                }
            
            Console.Write("Are you sure you want to delete these files and folders? (Y/N) ");
            
            while (true)
            {
                string answer = Console.ReadLine();

                if (answer != null && answer.ToLower() == "y")
                    return true;
                else if (answer != null && answer.ToLower() == "n")
                    return false;
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please, enter \"Y\" or \"N\" ");
                }
            }
            }
        }

        public void DeleteOlds(string path, int days)
        {
            var parce = new Parser();

            List<FileInfo> oldFiles = parce.GetOldFiles(path, days);
            List<DirectoryInfo> oldDirectories = parce.GetOldDirectories(path, days);
            bool confirmation = Confirmator(oldFiles, oldDirectories);

            if (!confirmation)
                return;
            else
            {
                foreach (FileInfo file in oldFiles)
                {
                    Console.WriteLine("Deleting " + file + "...");
                    try
                    {
                        file.Delete();
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Unable to delete this file.");
                    }
                }
                foreach (DirectoryInfo folder in oldDirectories)
                {
                    Console.WriteLine("Deleting " + folder + "...");
                    try
                    {
                        folder.Delete(true);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Unable to delete this file.");
                    }
                }
            }
        }
    }
}
