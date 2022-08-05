using System.Linq;

using BenchmarkDotNet.Attributes;

namespace Generator;

[MemoryDiagnoser]
public class Benchmark
{
    private readonly Builder _builder = new();

    [Benchmark(Description = "Use Span")]
    public string Test1()
    {
        return _builder.Generate(35, additionalSymbols: "!@#$%*(&*(!&)@$&_!)(*@$".ToArray());
    }

    [Benchmark(Description = "Use Array & Concat")]
    public string Test2()
    {
        return _builder.GenerateTrivial(35, additionalSymbols: "!@#$%*(&*(!&)@$&_!)(*@$".ToArray());
    }
}