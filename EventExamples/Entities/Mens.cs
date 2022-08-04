namespace Events.Entities;

internal class Mens : Humans
{
    private bool Sex { get; }
    public Mens(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
        Sex = true;
    }
}