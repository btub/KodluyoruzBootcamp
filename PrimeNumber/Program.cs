using System;

namespace PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool prime = true;

        Start:
            Console.Write("Number:");

            try
            {
                number = Convert.ToInt16(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid value.");
                goto Start;
            };

            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    prime = false;
            }

            if (number == 1)
                prime = false;

            if (prime)
                Console.WriteLine("Prime!");
            else
                Console.WriteLine("Not prime!");
        }
    }
}
