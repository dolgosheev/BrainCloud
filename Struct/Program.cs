using System;

namespace Struct
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            User tom;
            tom.name = null;
            tom.age = 34;
            tom.DisplayInfo();

            Console.ReadLine();
        }
    }

    struct User
    {
        public string name;
        public int age;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }
}
