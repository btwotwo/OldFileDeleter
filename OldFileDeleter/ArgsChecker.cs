using System.Text.RegularExpressions;
using System.IO;

namespace OldFileDeleter
{
    class ArgsChecker
    {
        public bool CheckPath(string path)
        {

            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDate(string days)
        {
            double day;
            if (double.TryParse(days, out day))
            {
                if(day <= 0)
                {
                    return false;
                }
                else
                    return true;

            }
            else
            {
                return false;
            }
        }
    }
}
