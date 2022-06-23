namespace Prove;

public class Todo
{
    private static readonly CancellationTokenSource CancelTokenSource = new();
    private readonly CancellationToken _token = CancelTokenSource.Token;

    public async Task TaskWithYieldAsync()
    {
        await Task.Yield();
        Thread.Sleep(150);
        Console.WriteLine($"Task 1 is completed at {DateTime.Now:F}");
    }

    public Task TaskWithoutYield()
    {
        Thread.Sleep(150);
        Console.WriteLine($"Task 1 is completed at {DateTime.Now:F}");
        return Task.CompletedTask;
    }

    public Task Task1Payload()
    {
        Thread.Sleep(150);
        Console.WriteLine($"Task 2 is completed at {DateTime.Now:F}");
        return Task.CompletedTask;
    }

    public Task Task2Payload()
    {
        Thread.Sleep(100);
        Console.WriteLine($"Task 3 is completed at {DateTime.Now:F}");
        return Task.CompletedTask;
    }

    public Task TaskWithCancel()
    {
        Console.WriteLine($"Task with error executed {DateTime.Now:F}");
        CancelTokenSource.Cancel();
        return Task.FromCanceled(_token);
    }
}