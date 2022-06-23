<h1>Benchmark Memory Tests</h1>

<pre>
// * Detailed results *
Tests.'Without await Task.Yield()': DefaultJob
Runtime = .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT; GC = Concurrent Workstation
Mean = 411.773 ms, StdErr = 0.552 ms (0.13%), N = 15, StdDev = 2.137 ms
Min = 407.570 ms, Q1 = 410.540 ms, Median = 411.419 ms, Q3 = 413.343 ms, Max = 415.449 ms
IQR = 2.803 ms, LowerFence = 406.335 ms, UpperFence = 417.548 ms
ConfidenceInterval = [409.489 ms; 414.058 ms] (CI 99.9%), Margin = 2.284 ms (0.55% of Mean)
Skewness = -0.05, Kurtosis = 2.1, MValue = 2
-------------------- Histogram --------------------
[406.433 ms ; 416.586 ms) | @@@@@@@@@@@@@@@
---------------------------------------------------

Tests.'With await Task.Yield() & Canceled Task': DefaultJob
Runtime = .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT; GC = Concurrent Workstation
Mean = 257.993 ms, StdErr = 0.583 ms (0.23%), N = 15, StdDev = 2.258 ms
Min = 253.463 ms, Q1 = 256.974 ms, Median = 258.109 ms, Q3 = 259.856 ms, Max = 261.315 ms
IQR = 2.882 ms, LowerFence = 252.651 ms, UpperFence = 264.179 ms
ConfidenceInterval = [255.579 ms; 260.407 ms] (CI 99.9%), Margin = 2.414 ms (0.94% of Mean)
Skewness = -0.34, Kurtosis = 2.08, MValue = 2
-------------------- Histogram --------------------
[252.262 ms ; 262.516 ms) | @@@@@@@@@@@@@@@
---------------------------------------------------

// * Summary *

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.4 (21F79) [Darwin 21.5.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.200
[Host]     : .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT
DefaultJob : .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT


|                                    Method |     Mean |   Error |  StdDev | Allocated |
|------------------------------------------ |---------:|--------:|--------:|----------:|
|              'Without await Task.Yield()' | 411.8 ms | 2.28 ms | 2.14 ms |      1 KB |
| 'With await Task.Yield() & Canceled Task' | 258.0 ms | 2.41 ms | 2.26 ms |     41 KB |
</pre>