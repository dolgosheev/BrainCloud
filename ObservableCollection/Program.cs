using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace ObservableCollection
{
    internal class Program
    {
        private static readonly ObservableCollection<Animal> Animals = new ObservableCollection<Animal>()
        {
            new Animal("Wolf",1),
            new Animal("Hare",2)
        };

        private static void Main()
        {
            Animals.CollectionChanged += Params_CollectionChanged;

            Animals.Add(new Animal("Camel", 3));

            Animals.Rm("Camel");

            Console.WriteLine($"Object with Title 'Camel' state is {Animals.Exist("Camel")}");

            Animals[0] = new Animal("Fox", 4);

            Console.WriteLine($"Object with Title 'Hare' index is {Animals.Index("Hare")}");


            Animals.Move(Animals.Index("Hare"), 0);


            Console.WriteLine("\n-----------------------\n");
            foreach (var animal in Animals)
            {
                Console.WriteLine($"{animal.Title} < start position {animal.Age} >");
            }

            Console.ReadKey();
        }

        private static void Params_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: 
                    var addAnimal = e.NewItems[0] as Animal;
                    Console.WriteLine($"Added a new object: {addAnimal?.Title} (age {addAnimal?.Age})");
                    break;
                case NotifyCollectionChangedAction.Remove: 
                    var removeAnimal = e.OldItems[0] as Animal;
                    Console.WriteLine($"Object removed:  {removeAnimal?.Title} (age {removeAnimal?.Age})");
                    break;
                case NotifyCollectionChangedAction.Replace: 
                    var replacedAnimal = e.OldItems[0] as Animal;
                    var replasingAnimal = e.NewItems[0] as Animal;
                    Console.WriteLine($"Object {replacedAnimal?.Title} replaced with an object {replasingAnimal?.Title}");
                    break;
                case NotifyCollectionChangedAction.Move:
                    var newAnimalIndex = e.NewStartingIndex;
                    var oldAnimalIndex = e.OldStartingIndex;
                    var animalIndexTitle = e.OldItems[0] as Animal;
                    Console.WriteLine($"Object {animalIndexTitle?.Title} moved from position {oldAnimalIndex} to position {newAnimalIndex}");
                    break;
            }
        }
    }

    internal static class ObservableCollectionAddition
    {
        public static bool Rm(this ObservableCollection<Animal> ok, string arg)
        {
            return ok.Remove(
                ok.Where(r => r.Title == arg).SingleOrDefault()
                );
        }

        public static bool Exist(this ObservableCollection<Animal> ok, string arg)
        {
            return ok.Contains(
                ok.Where(r => r.Title == arg).SingleOrDefault()
            );
        }

        public static int Index(this ObservableCollection<Animal> ok, string arg)
        {
            return ok.IndexOf(
                ok.Where(r => r.Title == arg).SingleOrDefault()
            );
        }
    }

    internal class Animal
    {
        public string Title { get; }

        public int Age { get; private set; }

        public Animal(string title, int age)
        {
            Title = title;
            Age = age;
        }
    }
}
