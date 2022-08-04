using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

var timer = new Timer(_ => { Console.WriteLine("Time is: {0}", DateTime.Now.ToLongTimeString()); }, null, 0, 1000);

Console.WriteLine("**** Start async operations ****\n");

await Parallel.ForEachAsync(
    Enumerable.Range(1, 5).Aggregate(new List<Task<string>>(), (list, item) =>
    {
        list.Add(ReturnMessage(item));
        return list;
    }),
    new ParallelOptions
    {
        MaxDegreeOfParallelism = 1
    }, async (tsk, _) => { Console.WriteLine(await tsk); });

Console.WriteLine($"{nameof(Program)} method invoked on thread {Environment.CurrentManagedThreadId}");

await timer.DisposeAsync();

async Task<string> ReturnMessage(int job)
{
    await Task.Delay(job * 1500);
    return $"Job {job} done thread => {Thread.CurrentThread.ManagedThreadId}";
}