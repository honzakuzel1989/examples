namespace JoinsExample
{
    public class Company : Base<Company>
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Title) ? "<NULL>" : Title;
        }
    }
}
