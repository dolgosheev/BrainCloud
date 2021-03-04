using System.Threading;

namespace DDOS_Attack
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                var ddos = new Ddos();
                Thread.Sleep(1000);
                ddos.Attack();
            }
        }
    }
}
