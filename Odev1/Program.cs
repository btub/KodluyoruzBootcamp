using System;

namespace Odev1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mass = 0;
            bool flag = true;
            
            double E = 0;
            Int32 c = 299792458; // Speed of light m/s

            Console.WriteLine("This program calculates your energy according to Einstein's Equation: E = mc2.");

            while (flag)
            {
                try
                {
                    Console.WriteLine("What is your weight?");
                    Console.Write("Weigtht: ");
                    mass = Convert.ToDouble(Console.ReadLine());
                    
                    if(0 <= mass)
                        flag = false;
                    else
                    {
                        Console.WriteLine("Weight cannot be negative.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid value.");
                }
            }

            E = mass * Math.Pow(c, 2);

            Console.WriteLine($"Your energy is {Convert.ToUInt64(E)} J (joule).");
        }
    }
}
