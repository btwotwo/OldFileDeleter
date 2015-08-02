using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OldFileDeleter
{
    class Deleter
    {
        private bool Confirmator(List<FileInfo> oldFiles)
        {
            if (oldFiles.Count == 0)
            {
                Console.WriteLine("You don't have any files in this directory");
                Console.ReadLine();
                return false;
            }


            else
            {
                foreach (FileInfo file in oldFiles)
                {
                    Console.WriteLine(file);
                }
            
            Console.Write("Are you sure you want to delete these files? (Y/N) ");
            
            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    return true;
                }
                else if (answer.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please, enter \"Y\" or \"N\" ");
                }
            }
            }
        }

        public void DeleteFiles(string path, int days)
        {
            Parcer parce = new Parcer();

            var oldFiles = new List<FileInfo>();
            oldFiles = parce.GetOldFiles(path, days);
            bool confirmation = Confirmator(oldFiles);

            if (!confirmation)
            {
                return;
            }
            else
            {
                foreach (FileInfo file in oldFiles)
                {
                    Console.WriteLine("Deleting " + file + " ...");
                    try {
                        file.Delete();
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
