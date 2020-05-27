namespace JoinsExample
{
    public class Person : Base<Person>
    {
        public int Company_ID { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(FullName) ? "<NULL>" : FullName;
        }
    }
}
