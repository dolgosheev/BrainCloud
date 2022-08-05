using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

using CollectionObserve;

var animals = new ObservableCollection<Animal>
{
    new("Wolf", 1),
    new("Hare", 2)
};

animals.CollectionChanged += CollectionChanged;

animals.Add(new Animal("Camel", 3));
animals.Rm("Camel");
Console.WriteLine($"Object with Title 'Camel' state is {animals.Exist("Camel")}");

animals[0] = new Animal("Fox", 4);
Console.WriteLine($"Object with Title 'Hare' index is {animals.Index("Hare")}");

animals.Move(animals.Index("Hare"), 0);
Console.WriteLine("\n-----------------------\n");

animals.ToList().ForEach(animal => { Console.WriteLine($"{animal.Title} < start position {animal.Age} >"); });

Console.ReadKey();

static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
{
    switch (e.Action)
    {
        case NotifyCollectionChangedAction.Add:
        {
            if (e.NewItems?[0] is Animal addAnimal)
                Console.WriteLine($"Added a new object: {addAnimal.Title} (age {addAnimal.Age})");
            break;
        }
        case NotifyCollectionChangedAction.Remove:
            if (e.OldItems?[0] is Animal removeAnimal)
                Console.WriteLine($"Object removed:  {removeAnimal.Title} (age {removeAnimal.Age})");
            break;
        case NotifyCollectionChangedAction.Replace:
            if (e.OldItems?[0] is Animal replacedAnimal && e.NewItems?[0] is Animal replacingAnimal)
                Console.WriteLine($"Object {replacedAnimal.Title} replaced with an object {replacingAnimal.Title}");
            break;
        case NotifyCollectionChangedAction.Move:
            if (e.OldItems?[0] is Animal animalIndexTitle)
                Console.WriteLine(
                    $"Object {animalIndexTitle.Title} moved from position {e.OldStartingIndex} to position {e.NewStartingIndex}");
            break;
        case NotifyCollectionChangedAction.Reset:
        default:
            break;
    }
}