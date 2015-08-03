using System.Text.RegularExpressions;
using System.IO;

namespace OldFileDeleter
{
    class ArgsChecker
    {
        public bool CheckPath(string path)
        {
            return path != null && Directory.Exists(path);
        }

        public bool CheckDate(string days)
        {
            double day;
            return double.TryParse(days, out day) && !(day <= 0);
        }
    }
}
