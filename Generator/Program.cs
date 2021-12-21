using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Generated code : {Generate(26, additionalSymbols: "!@#$%^&*()+_".ToArray())}");
        }

        public static string Generate(byte length,
            bool digits = true,
            bool upperCase = true,
            bool lowerCase = true,
            params char[] additionalSymbols)
        {
            IEnumerable<int> asciiList = new int[] { };

            if (digits) /* 0-9 */
                asciiList = asciiList.Concat(Enumerable.Range(48, 10));

            if (upperCase) /* A-Z */
                asciiList = asciiList.Concat(Enumerable.Range(65, 26));

            if (lowerCase) /* a-z */
                asciiList = asciiList.Concat(Enumerable.Range(97, 26));

            if (additionalSymbols.Length > 0) /* your symbols */
                asciiList = asciiList.Concat(additionalSymbols.Select(x => (int) x));

            var asciiArrayByParams = asciiList as int[] ?? asciiList.ToArray();

            if (asciiArrayByParams.Length <= 0)
                return string.Empty;

            return new string(
                Enumerable
                    .Repeat(asciiArrayByParams.Select(x => (char) x).Distinct().ToArray(), length)
                    .Select(x => x[new Random().Next(x.Length)])
                    .ToArray()
            );
        }
    }
}