using System;

namespace Odev2b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool prime;
            Console.WriteLine(2);
            for (int i = 3; i < 10000; i+=2)
            {
                prime = true;
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if(i%j == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if(prime)
                    Console.WriteLine(i);
            }
        }
    }
}
