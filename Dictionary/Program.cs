using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dictionary
{
    internal class Program
    {
        private static void Main()
        {
            var file = "./config.conf"; // F4 copy if newer

            var configFile = new ReadConfig(file);

            Console.WriteLine($"All keys from config | {file}\n");
            Array.ForEach(configFile.coonfig.Keys.ToArray(), Console.WriteLine);

            Console.WriteLine($"\nOr thin value \"user\" for example is : {configFile.coonfig["user"]}");
            Console.ReadKey();
        }
    }

    internal class ReadConfig
    {
        private readonly Dictionary<string,string> _config = new Dictionary<string, string>();

        public Dictionary<string, string> coonfig => _config;

        public ReadConfig(string file)
        {
            using (var sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var r = VerifyValue(line);
                    _config.TryAdd(r.Item1, r.Item2);
                }
            }
        }

        private Tuple<string, string> VerifyValue(string line)
        {
            if (line.StartsWith('#') || line.StartsWith('/') || string.IsNullOrWhiteSpace(line))
                return default;

            var splitLine = line.Split("=");
                return new Tuple<string, string>(splitLine[0], string.IsNullOrWhiteSpace(splitLine[1]) ? default : splitLine[1]);
        }
    }
}
