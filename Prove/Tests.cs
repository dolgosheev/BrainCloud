using System.Diagnostics;

using BenchmarkDotNet.Attributes;

namespace Prove;

[MemoryDiagnoser]
public class Tests
{
    private readonly Todo _todo = new();

    [Benchmark(Description = "Without await Task.Yield()")]
    public void Exec1()
    {
        var timer1 = Stopwatch.StartNew();
        Task.WaitAll(_todo.TaskWithoutYield(), _todo.Task1Payload(), _todo.Task2Payload());
        timer1.Stop();

        Console.WriteLine(
            "Task completes without Yield" +
            $" - Taken time [{(double) timer1.ElapsedMilliseconds / 1000}]s\r\n");
    }

    [Benchmark(Description = "With await Task.Yield() & Canceled Task")]
    public void Exec2()
    {
        var timer2 = Stopwatch.StartNew();
        var tasksWithYield = new List<Task>
        {
            _todo.TaskWithYieldAsync(),
            _todo.Task1Payload(),
            _todo.Task2Payload(),
            _todo.TaskWithCancel()
        };
        try
        {
            Task.WaitAll(tasksWithYield.ToArray());
        }
        catch (AggregateException)
        {
            Console.WriteLine("Status of tasks:\n");
            Console.WriteLine("{0,10} {1,20}", "Task Id",
                "Status");

            foreach (var t in tasksWithYield)
                Console.WriteLine("{0,10} {1,20}",
                    t.Id, t.Status);
        }

        timer2.Stop();

        Console.WriteLine(
            "Task completes with Yield" +
            $" - Taken time [{(double) timer2.ElapsedMilliseconds / 1000}]s");
    }
}