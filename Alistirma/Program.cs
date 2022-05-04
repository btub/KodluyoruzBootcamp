using System;
using System.Collections.Generic;
using System.Linq;

namespace Alistirma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    string[] cities = { "ankara", "ANKARA", "izmir", "istanbul", "İstanbul", "Muğla" };

            //    foreach (var item in GetCities(cities.ToList()))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //static List<string> GetCities(List<string> cities)
            //{
            //    List<string> list = new List<string>();

            //    foreach (string c in cities)
            //    {
            //        if(!list.Contains(c.ToUpper()))
            //            list.Add(c.ToUpper());
            //    }
            //    return list;


            List<int> array = new List<int>();
            int num = 0;
            string s = "cdefghmnopqrstuvw";

            for (char i = 'a'; i <= 'z'; i++)
            {
                array.Add(0);
                foreach (char c in s)
                {
                    if (i == c)
                        array[num]++;
                }
                num++;
            }

            int even = 0, odd = 0;

            array.RemoveAll(x => x == 0);

            foreach (var item in array)
            {
                if (item % 2 != 0)
                    odd++;
            }

            if (odd > 1)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");

}
    }
}
