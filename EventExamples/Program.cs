using System;

using Events.Classes;
using Events.Interfaces;

namespace Events
{
    internal static class Program
    {
        private static void Main()
        {
            Humans.HumanEditions += Human_HumanEditions;
            Humans.HumanCreated += Humans_HumanCreated;

            IHuman men = new Mens("Alexander", "Dolgosheev", 33);
            IHuman women = new Womens("Marina", "Dolgosheeva", 32);

            men.PlusYearAge();
            women.PlusYearAge();

            Console.ReadKey();
        }

        private static void Humans_HumanCreated(object sender, IHuman e)
        {
            Console.WriteLine($"Created {e.Fname} {e.Sname} age {e.Age}");
        }

        private static void Human_HumanEditions(object sender, IHuman e)
        {
            Console.WriteLine($"Age for {e.Fname} {e.Sname} has been changed to {e.Age}");
        }
    }
}