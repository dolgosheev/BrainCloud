namespace Events.Entities;

internal class Womens : Humans
{
    private bool Sex { get; }

    public Womens(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
        Sex = false;
    }
}