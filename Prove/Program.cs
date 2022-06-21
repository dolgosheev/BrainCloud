using System.Diagnostics;

Console.WriteLine("Start");

var todo = new Todo();

/* Correct construction */
var errorTask = todo.TaskWithCancel();
if (errorTask.IsCanceled || errorTask.IsFaulted)
    Console.WriteLine("Some problems with task");

/* Incorrect construction 
 * calls : Unhandled exception. System.Threading.Tasks.TaskCanceledException: A task was canceled.
 */
//var errorTaskIncorrect =  await todo.TaskWithCancel();

var timer1 = Stopwatch.StartNew();
Task.WaitAll(todo.TaskWithoutYield(), todo.Task1Payload(), todo.Task2Payload());
timer1.Stop();

Console.WriteLine(
    "Task completes without Yield" +
    $"\r\nTaken time [{(double) timer1.ElapsedMilliseconds / 1000}]s");

var timer2 = Stopwatch.StartNew();
Task.WaitAll(todo.TaskWithYield(), todo.Task1Payload(), todo.Task2Payload());
timer2.Stop();

Console.WriteLine(
    "Task completes with Yield" +
    $"\r\nTaken time [{(double) timer2.ElapsedMilliseconds / 1000}]s");

public class Todo
{
    private static readonly CancellationTokenSource cancelTokenSource = new();
    private readonly CancellationToken token = cancelTokenSource.Token;

    public async Task TaskWithYield()
    {
        await Task.Yield();
        Thread.Sleep(1500);
        Console.WriteLine($"Task 1 is completed at {DateTime.Now:F}");
    }

    public Task TaskWithoutYield()
    {
        Thread.Sleep(1500);
        Console.WriteLine($"Task 1 is completed at {DateTime.Now:F}");
        return Task.CompletedTask;
    }

    public Task Task1Payload()
    {
        Thread.Sleep(1500);
        Console.WriteLine($"Task 2 is completed at {DateTime.Now:F}");
        return Task.CompletedTask;
    }

    public Task Task2Payload()
    {
        Thread.Sleep(1500);
        Console.WriteLine($"Task 3 is completed at {DateTime.Now:F}");
        return Task.CompletedTask;
    }

    public Task<int> TaskWithCancel()
    {
        Console.WriteLine($"Task with error executed {DateTime.Now:F}");

        // if (new Random().Next(1, 3) == 1) return Task.FromResult(10);
        
        cancelTokenSource.Cancel();
        return Task.FromCanceled<int>(token);
    }
}