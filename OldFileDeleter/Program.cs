using System;

namespace OldFileDeleter
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"Please write arguments in this format: ""path:\to\directory"" ""the number of weeks from the last opening"" ");
                Console.ReadLine();
                return;
            }
            string path = args[0];
            string date = args[1];

            var check = new ArgsChecker();

            if (!check.CheckPath(path))
            {
                Console.Write("Please enter valid path");
                Console.ReadLine();
                return;
            }

            if (!check.CheckDate(date))
            {
                Console.Write("Please enter valid date");
                Console.ReadLine();
                return;
            }

            var delete = new Deleter();
            delete.DeleteFiles(path, int.Parse(date) * 7);

        }
    }
}
