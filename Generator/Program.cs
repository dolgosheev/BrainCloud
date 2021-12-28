using System;
using System.Linq;

namespace Generator
{
    internal static class Program
    {
        private static void Main()
        {
            var generator = new Generator();
            Console.WriteLine(generator.Generate(35, additionalSymbols: "!@#$%*(&*(!&)@$&_!)(*@$".ToArray()));
        }
    }
}