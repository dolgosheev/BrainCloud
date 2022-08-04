namespace Events.Classes
{
    internal class Mens : Humans
    {
        public bool Sex { get; }
        public Mens(string fname, string sname, int age) : base(fname, sname, age)
        {
            Sex = true;
        }
    }
}