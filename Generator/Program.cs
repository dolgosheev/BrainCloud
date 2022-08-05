using System;
using System.Linq;

using BenchmarkDotNet.Running;

using Generator;

Builder generator = new();
Console.WriteLine(generator.Generate(35, additionalSymbols: "!@#$%*(&*(!&)@$&_!)(*@$".ToArray()));

BenchmarkRunner.Run<Benchmark>();