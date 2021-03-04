using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace ConcurrentDictionary
{
    internal class Program
    {
        private static readonly ConcurrentDictionary<long, Person> ConcurentTrainerSessions = new ConcurrentDictionary<long, Person>();

        private static void Main()
        {

            // add
            var alexander = new Person("Alexander");
            var marina = new Person("Marina");
            var alice = new Person("Alice");

            // try add
            ConcurentTrainerSessions.AddOrUpdate(1, alexander, (l, person) => alexander);
            ConcurentTrainerSessions.AddOrUpdate(2, marina, (l, person) => marina);
            ConcurentTrainerSessions.AddOrUpdate(3, alice, (l, person) => alice);

            // try remove
            if (ConcurentTrainerSessions.TryRemove(2, out var personTr))
                Console.WriteLine($" *** {personTr.Name} deleted ***");


            if (ConcurentTrainerSessions.TryGetValue(11, out var personTg))
                Console.WriteLine($" *** {personTg.Name} getted ***");


            foreach (var (k, v) in ConcurentTrainerSessions)
            {
                Console.WriteLine($"{k} {v.Name} {v.Token}");
            }

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; }
        public string Token { get; }

        public Person(string name)
        {
            Name = name;
            Token = new Regex("[*'\"/,_&#^@+=]").Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), string.Empty);
        }
    }
}