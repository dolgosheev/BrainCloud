using System;

using Events.Interfaces;

namespace Events.Entities;

internal class Humans : IHuman
{
    public static event EventHandler<IHuman> HumanCreated;
    public static event EventHandler<IHuman> HumanEditions;

    public string FirstName { get;}
    public string LastName { get;}
    public int Age { get; private set; }
    public void PlusYearAge()
    {
        Age++;
        HumanEditions?.Invoke(this,this);
    }
    protected Humans(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        HumanCreated?.Invoke(this, this);
    }

}