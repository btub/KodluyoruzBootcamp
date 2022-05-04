using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyExtensions // static olmak zorunda
    {
        public static double GetPower2(this int val)
        {
            return val * val;
        }

        public static double GetPower(this int val, double pow)
        {
            return Math.Pow(val, pow);
        }

        public static int TotalWorkDays(this DateTime dateTime)
        {
            DateTime startDate = new DateTime(dateTime.Year, 1, 1);
            DateTime endDate = new DateTime(dateTime.Year, 12, 31);

            int output = 0;
            for(DateTime current = startDate; current<=endDate;current=current.AddDays(1))
            {
                if(current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                else
                {
                    output++;
                }
            }
            return output;
        }

        public static int TotalWorkDays(this DateTime dateTime, List<DateTime> holidays)
        {
            DateTime startDate = new DateTime(dateTime.Year, 1, 1);
            DateTime endDate = new DateTime(dateTime.Year, 12, 31);

            int output = 0;
            for (DateTime current = startDate; current <= endDate; current = current.AddDays(1))
            {
                if (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday || holidays.Contains(current))
                {
                    continue;
                }
                else
                {
                    output++;
                }
            }
            return output;
        }
    
        public static string NextLetter(this Random random)
        {
            int num = new Random().Next(65, 91);
            return ((char)num).ToString();
        }

        public static string NextWord(this Random random,int len = 3)
        {
            string output = string.Empty;

            for (int i = 0; i < len;i++)
            {
                output += random.NextLetter();
            }
            return output;
        }
    }
}
