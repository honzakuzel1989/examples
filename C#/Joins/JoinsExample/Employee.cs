namespace JoinsExample
{
    class Employee
    {
        public int? Id { get; set; }
        public string Fullname { get; set; }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
