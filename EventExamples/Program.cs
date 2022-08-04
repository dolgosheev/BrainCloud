using System;

using Events.Entities;
using Events.Interfaces;


Humans.HumanCreated += (sender, human) =>
{
    Console.WriteLine($"Created {human.FirstName} {human.LastName} age {human.Age}");
};
Humans.HumanEditions += (sender, human) =>
{
    Console.WriteLine($"Age for {human.FirstName} {human.LastName} has been changed to {human.Age}");
};

IHuman men = new Mens("Alexander", "Dolgosheev", 33);
IHuman women = new Womens("Marina", "Dolgosheeva", 32);

men.PlusYearAge();
women.PlusYearAge();

Console.ReadKey();