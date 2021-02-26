namespace Events.Classes
{
    internal class Womens : Humans
    {
        public bool Sex { get; }

        public Womens(string fname, string sname, int age) : base(fname, sname, age)
        {
            Sex = false;
        }
    }
}