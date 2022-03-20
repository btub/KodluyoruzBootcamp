using System;

namespace Odev2a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool prime = true;

            Console.Write("Number:");

            try
            {
                number = Convert.ToInt16(Console.Read());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid value.");
            };

            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if(number%i == 0)
                    prime = false;
            }

            if (prime)
                Console.WriteLine("Prime!");
            else
                Console.WriteLine("Not prime!");
        }
    }
}
