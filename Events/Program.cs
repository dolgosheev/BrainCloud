/*
 * Author : Alexander Dolgosheev
 * Github : https://github.com/dolgosheev
 * Mailto : alexanderdolgosheev@gmail.com
 */

using System;

namespace Events
{

    internal static class Program
    {
        private static void Main()
        {
            Humans.HumanEditions += Human_HumanEditions;
            Humans.HumanCreated += Humans_HumanCreated;

            IHuman men = new Mens("Alexander","Dolgosheev",33);
            IHuman women = new Mens("Marina","Dolgosheeva",32);

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

    internal interface IHuman
    {
        public string Fname { get; }
        public string Sname { get; }
        public int Age { get; }

        public void PlusYearAge();
    }

    internal class Mens : Humans
    {
        public bool Sex { get; }
        public Mens(string fname, string sname, int age) : base(fname, sname, age)
        {
            Sex = true;
        }
    }

    internal class Womens : Humans
    {
        public bool Sex { get; }

        public Womens(string fname, string sname, int age) : base(fname, sname, age)
        {
            Sex = false;
        }
    }

    internal class Humans : IHuman
    {
        public static event EventHandler<IHuman> HumanCreated;
        public static event EventHandler<IHuman> HumanEditions;
        public string Fname { get;}
        public string Sname { get;}
        public int Age { get; private set; }
        public void PlusYearAge()
        {
            Age++;
            HumanEditions?.Invoke(this,this);
        }
        protected Humans(string fname, string sname, int age)
        {
            Fname = fname;
            Sname = sname;
            Age = age;
            HumanCreated?.Invoke(this, this);
        }

    }
}
