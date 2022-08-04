using System.Diagnostics;

using BenchmarkDotNet.Running;

using Prove;

Console.WriteLine("Start\r\n");

//BenchmarkRunner.Run<Tests>();

var timer = Stopwatch.StartNew();

Thread.CurrentThread.Name = "Named Thread";


Task.Run(/*async*/ ()=>
{
    //await Task.Yield();
    Console.WriteLine($"Hello {new Random().Next(0,1001)}");
    //return Task.CompletedTask;
    GC.Collect((int) GCCollectionMode.Forced);
});

while (true)
{
    var cnt = ThreadPool.ThreadCount;
    
    if(cnt<=1)
    {
        timer.Stop();
        Console.WriteLine($"Unused threads disposed, taken [{(double)timer.ElapsedMilliseconds/1000}]s");
        break;
    }
    
    Console.WriteLine($"Threads count - {cnt}, Current - {Thread.CurrentThread.Name}");
    Thread.Sleep(500);
}