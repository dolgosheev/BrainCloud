using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Generator;

namespace Generator
{
    public class Benchmark
    {
        Generator generator = new Generator();
        
        [Benchmark(Description = "Use Span")]
        public string Test1()
        {
            return generator.Generate(35, additionalSymbols: "!@#$%*(&*(!&)@$&_!)(*@$".ToArray());
        }

        [Benchmark(Description = "Use Array & Concat")]
        public string Test2()
        {
            return generator.GenerateTrivial(35, additionalSymbols: "!@#$%*(&*(!&)@$&_!)(*@$".ToArray());
        }
    }
}