namespace Events.Interfaces
{
    internal interface IHuman
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public void PlusYearAge();
    }
}