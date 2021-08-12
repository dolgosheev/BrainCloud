using System;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("*** Algorithms ***");


            var digitForReverse = 123;
            Console.WriteLine($"Reverse of {digitForReverse} is {await Algorithms.DigitReverse(digitForReverse)}");


        }
    }

    internal static class Algorithms
    {
        public static async Task<long> DigitReverse(long digit)
        {
            var task = Task.Run(() =>
            {
                long b = 0;

                while (digit > 0)
                {
                    b = b * 10 + digit % 10;
                    digit = digit / 10;
                }

                return b;
            });

            return await task;
        }

    }
}
