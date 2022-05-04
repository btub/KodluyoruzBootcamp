using System;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 8;

            x.GetPower2();
            x.GetPower(3);

            DateTime.Now.TotalWorkDays();

            Random random = new Random();
            random.NextLetter();
            random.NextWord(4);
        }
    }
}
