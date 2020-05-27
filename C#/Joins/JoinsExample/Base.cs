namespace JoinsExample
{
    public abstract class Base<T> where T : new()
    {
        public static T NullObject { get; } = new T();
        public int ID { get; set; }
    }
}
