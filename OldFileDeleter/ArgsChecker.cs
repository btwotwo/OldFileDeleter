using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OldFileDeleter
{
    class ArgsChecker
    {
        public bool CheckPath(string path)
        {
            string regex = @"^(?:[\w]\:)(\/[a-z_\-\s0-9\.]+)+$";
            Regex reg = new Regex(regex, RegexOptions.IgnoreCase);

            Match m = reg.Match(path);

            if (m.Success)
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
