using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAndAsync
{
    internal class Program
    {
        private static readonly ConcurrentDictionary<int, long> Results = new();

        private static readonly EventHandler<long> Interaction = InteractionCall;

        private static void InteractionCall(object sender, long e)
        {
            Results.TryAdd((int) sender, e);
        }

        private static void Main()
        {
            var tasks = new List<Task>();

            for (var i = 1; i <= 9; i++) tasks.Add(_task(i));

            while (true)
            {
                Console.WriteLine("Wait for all...");
                for (var i = tasks.Count - 1; i >= 0; i--)
                    if (tasks[i].IsFaulted || tasks[i].IsCanceled)
                    {
                        Console.WriteLine($"Task result [{tasks[i]?.Exception?.Message}] | removed]");
                        tasks.RemoveAt(i);
                    }

                foreach (var result in Results)
                {
                    if (result.Value == 0)
                    {
                        Console.WriteLine("Have no results...");
                        break;
                    }

                    Console.WriteLine($"Factorial of [{result.Key}] is [{result.Value}]");
                }

                if (tasks.All(x => x.IsCompleted))
                    break;

                Thread.Sleep(1000);
            }

            Console.WriteLine("Job Done!");
            Console.Read();
        }

        private static Task _task(int x)
        {
            return Task.Run(async () => { Interaction?.Invoke(x, await FactorialAsync(x)); });
        }

        private static long Factorial(int n)
        {
            var result = 1;
            for (var i = 1; i <= n; i++)
                result *= i;

            if (new Random().Next(0, 2) > 0)
                throw new Exception("Simulation...");

            return result;
        }

        private static async Task<long> FactorialAsync(int n)
        {
            var res = await Task.Run(() => Factorial(n));
            await Task.Delay(new Random().Next(1000, 3000));
            return res;
        }
    }
}