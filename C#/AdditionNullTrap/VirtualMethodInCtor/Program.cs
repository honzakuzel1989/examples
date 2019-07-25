using System;

namespace VirtualMethodInCtor
{
    abstract class A
    {
        public A()
        {
            F();
        }

        protected abstract void F();
    }

    class B : A
    {
        string msg = "B.msg";

        public B(string msg)
        {
            this.msg = msg;
        }

        protected override void F()
        {
            Console.WriteLine(msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var _ = new B("Program");
            Console.ReadLine();
        }
    }
}
