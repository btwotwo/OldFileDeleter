using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OldFileDeleter
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"Please write arguments in this format: @""path:\to\directory"" ""the number of weeks from the last opening"" ");
                Console.ReadLine();
                return;
            }


            ArgsChecker check = new ArgsChecker();

            if (!check.CheckPath(args[0]))
            {
                Console.Write("Please enter valid path");
                Console.ReadLine();
                return;
            }

            if (!check.CheckDate(args[1]))
            {
                Console.Write("Please enter valid date");
                Console.ReadLine();
                return;
            }

            Deleter delete = new Deleter();
            delete.DeleteFiles(args[0], int.Parse(args[1]) * 7);

        }
    }
}
