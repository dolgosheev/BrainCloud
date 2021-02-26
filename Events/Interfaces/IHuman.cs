namespace Events.Interfaces
{
    internal interface IHuman
    {
        public string Fname { get; }
        public string Sname { get; }
        public int Age { get; }

        public void PlusYearAge();
    }
}