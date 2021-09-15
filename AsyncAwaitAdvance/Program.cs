using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitAdvance
{
    internal class Program
    {
        private static readonly CancellationTokenSource Cancellation = new CancellationTokenSource();

        private static async Task Main()
        {
            Cancellation.CancelAfter(4000);

            var task1 = Task1();
            var task2 = Task2(Cancellation.Token);
            var task3 = Task3();

            var taskList = new List<Task> { task1, task2, task3 };

            while (taskList.Count > 0)
            {
                var finishedTask = await Task.WhenAny(taskList);

                if (taskList.Contains(finishedTask))
                    Console.WriteLine($"Task {taskList.IndexOf(finishedTask) + 1} are ready");

                taskList.Remove(finishedTask);
            }

            Console.WriteLine(Thread.CurrentThread.Name);
            Console.ReadKey();
        }

        private static async Task Task1()
        {
            var raw = "InMemoryConnectionString=127.0.0.1:6844,abortConnect=False,password=kjl7hLKg5jkFk5hgFj5hf354gjk1hG";
            var result = raw.Split('=').Skip(1).Aggregate((a, b) => string.Concat(a, '=', b));
            await Task.Delay(1500);
            Console.WriteLine(result);
        }

        private static async Task Task2(CancellationToken token)
        {
            var result = "Task 2";
            await Task.Delay(1000);

            while (!token.IsCancellationRequested)
            {
                Console.WriteLine($"I can't wait [{result}] | :D");
                Task.Delay(1000).Wait();
            }
        }

        private static async Task Task3()
        {
            var result = "Task 3";
            await Task.Delay(500);
            Console.WriteLine(result);
        }

    }
}
