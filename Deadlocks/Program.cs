using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlocks
{
    internal class Program
    {
        private static readonly object Locker = new object();
        private static void Main()
        {

            _ = WriteToAsync("test.txt", "One");
            _ = WriteToAsync("test.txt", "Two");
            _ = WriteToAsync("test.txt", "Three");
            _ = WriteToAsync("test.txt", "Four");

            short i = 1;
            decimal summ = 1;

            while (i++ < 3)
            {
                Thread.Sleep(300);
                summ *= i;
            }
            Console.WriteLine($"I'm happy {summ}");
        }

        public static void WriteTo(string path, string text, int delayMs = 0)
        {

            lock (Locker)
            {
                using (var sw = new StreamWriter(path, true, Encoding.UTF8))
                {
                    var cnt = 10;
                    while (cnt-- > 0)
                    {
                        Thread.Sleep(delayMs);
                        sw.WriteLine(text);
                    }
                }
            }

        }

        private static async Task WriteToAsync(string testTxt, string hello, int delayMs = 0)
        {
            await Task.Run(() => WriteTo(testTxt, hello, delayMs));
        }
    }
}