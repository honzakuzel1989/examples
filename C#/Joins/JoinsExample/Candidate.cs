namespace JoinsExample
{
    class Candidate
    {
        public int? Id { get; set; }
        public string Fullname { get; set; }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
