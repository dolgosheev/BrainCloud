using System;
using System.Threading;
using System.Threading.Tasks;


namespace AsyncAwait
{
    internal class Program
    {
        private static async Task Main()
        {
            TimerCallback timeCb = PrintTime;

            Console.WriteLine("**** Start async operations ****\n\n");

            var _ = new Timer(
                timeCb, // Delegate Obj TimerCallback.
                null, // Information to transfer to the induced method
                0, // Pre-launch waiting period (in milliseconds)
                1000);// Interval between calls (in milliseconds).

            Console.WriteLine(await ReturnMessage(2));
            Console.WriteLine(await ReturnMessage(1));

            Console.WriteLine("Main() method invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }

        private static async Task<string> ReturnMessage(int jobnum)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return string.Format("Job {0} done thread => {1}", jobnum, Thread.CurrentThread.ManagedThreadId);
            });
        }

        private static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}", DateTime.Now.ToLongTimeString());
        }

    }
}