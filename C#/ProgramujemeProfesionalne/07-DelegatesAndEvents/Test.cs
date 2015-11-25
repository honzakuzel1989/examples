using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Windows.Forms;

namespace _07_DelegatesAndEvents
{
    public class Test : IChapter
    {
        #region IChapter Members

        public void Run()
        {
            Console.WriteLine("Chapter seven - Delegates and events.");
            Console.WriteLine("=====================================");

            //_1();
            //_2(new IntMethodInvoker(IntMethod), 10);
            //Console.WriteLine(_3(new CompareMethod(Comparator), 10, 200));
            //Console.WriteLine(_3(new CompareMethod(Comparator2), 10, 200));
            //_4(SortMethod.MERGE);
            //_5();
            //_6();
            //_7();
            //_8();
            //UI example
            //_9();
            //_10();
        }

        #endregion

        delegate void IntMethodInvoker(int x);
        delegate int CompareMethod(int x, int y);

        private void _1()
        {
            System.Threading.Thread t = new System.Threading.Thread(Dummy);
            t.Start();
        }

        private void Dummy()
        {
            //Thread code
            //...
        }

        private void _2(IntMethodInvoker imi, int x)
        {
            imi(x);
        }

        private void IntMethod(int x)
        {
            Console.WriteLine("Toto je int:{0}", x);
        }

        private int _3(CompareMethod compare, int x, int y)
        {
            return compare(x, y);
        }

        private int Comparator(int x, int y)
        {
            //Simple and stupid int comparator
            int x2 = x * x;
            if (x2 == y)
                return 0;
            else if (x * x > y)
                return 1;
            else
                return -1;
        }

        private int Comparator2(int x, int y)
        {
            //Even worse comparator than Comparator
            return Comparator(x, y) * -1;
        }

        private delegate bool BaseToString(int[] array);
        private enum SortMethod { BUBBLE, QUICK, HEAP, MERGE, PM, OTHER }

        private void _4(SortMethod sm)
        {
            BaseToString bs;

            switch (sm)
            {
                case SortMethod.BUBBLE: bs = bubble; break;
                case SortMethod.HEAP:   bs = heap;   break;
                case SortMethod.QUICK:  bs = quick;  break;
                case SortMethod.MERGE:  bs = merge;  break;
                //....
                default: bs = bubble; break;
            }

            bs(new int[] { 1, 2, 3, 4, 5 });

            BaseToString[] bss = new BaseToString[] { bubble, heap, quick, merge };
            foreach (BaseToString bts in bss)
            {
                bts(new int[] { 1, 2, 3, 4, 5 });
            }

            for (int i = 0; i < bss.Length; i++ )
            {
                bss[i](new int[] { 1, 2, 3, 4, 5 });
            }
        }

        private bool bubble(int[] array)
        {
            Console.WriteLine("I'm bubble sort.");
            return true;
        }

        private bool heap(int[] array)
        {
            Console.WriteLine("I'm heap sort.");
            return true;
        }

        private bool quick(int[] array)
        {
            Console.WriteLine("I'm quick sort.");
            return true;
        }

        private bool merge(int[] array)
        {
            Console.WriteLine("I'm merge sort.");
            return true;
        }

        private delegate int Compare<T>(T x, T y) where T : IComparable<T>;

        private void _5()
        {
            //Generic delegate
            var test = new Compare<int>(GenericCompare);
            Console.WriteLine(test(30, 20));
            var test2 = new Compare<string>(GenericCompare);
            Console.WriteLine(test2("0", "20"));
        }

        //Generic method use with generic delegate
        private int GenericCompare<T>(T x, T y) where T : IComparable<T>
        {
            return x.CompareTo(y);
        }

        public struct ProductInfo
        {
            public string name;
            public float version;
            public string description;
        }

        private delegate void PrintInfo(ProductInfo pi);

        private void PrintName(ProductInfo pi)
        {
            Console.WriteLine(">" + pi.name);
        }

        private void PrintVersion(ProductInfo pi)
        {
            Console.WriteLine("#" + pi.version);
        }
        
        private void PrintDescription(ProductInfo pi)
        {
            Console.WriteLine("-" + pi.description);
        }

        //Multiple delegate
        private void _6()
        {
            PrintInfo pi = new PrintInfo(PrintName);
            pi += new PrintInfo(PrintVersion);
            pi += new PrintInfo(PrintDescription);

            //The order of the call methods are NOT formally defined
            //In case of exeption in whatever call is chain ended - solution is use GetInvocationList() method
            pi(new ProductInfo(){name="Jmeno", description="Testovaci popis", version=1.3f});
            Delegate[] pis = pi.GetInvocationList();

            //In forech is concrete delegate type, no just Delegate (PrintInfo)!
            foreach (PrintInfo d in pis)
            {
                try
                {
                    d(new ProductInfo() { name = "Jmeno", description = "Testovaci popis", version = 1.3f });
                }
                catch (Exception)
                {
                    /* Catching exceptions */
                }
            }
        }

        //Anonymous method
        private void _7()
        {
            //Reduce resources
            PrintInfo pi = delegate(ProductInfo param)
            {
                Console.WriteLine("{0}-{1}:v.{2}", param.name, param.description, param.version);
            };

            pi(new ProductInfo() { name = "test", description = "masakralni test", version = 1.0f });
        }

        //Lambda expression
        private void _8()
        {
            //Datatype of the parameter in the lambda expression is optional
            PrintInfo pi = (ProductInfo param) => Console.WriteLine("{0}-{1}:v.{2}", param.name, param.description, param.version);
            //For composite command is possible to use {}
            pi(new ProductInfo() { name = "test", description = "masakralni test", version = 1.0f });
        }

        private void _9()
        {
            Form f = new Form();
            f.Height = 240; f.Width = 320;

            Button b = new Button();
            b.Text = "Click Me!";
            b.Click += (object sender, EventArgs e) => MessageBox.Show("Click 1!");
            b.Click += delegate(object sender, EventArgs e)
            {
                MessageBox.Show("Click 2!");
            };
            //The compiler generates new EventHandler(b_click) insted b_Click
            b.Click += b_Click;
            b.Dock = DockStyle.Fill;

            f.Controls.Add(b);
            f.ShowDialog();
        }

        //The event handlers must not return value
        void b_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click 3!");
        }

        //Delegate and corresponding event
        //Delegate use special EventArgs
        public delegate void MyActionEventHandler(object sender, MyActionEventArgs ev);
        public static event MyActionEventHandler MyAction;

        private void _10()
        {
            //Action registration
            MyAction += new MyActionEventHandler(OnMyAction);
            if (MyAction != null)
            { 
                //Action call
                MyActionEventArgs ea = new MyActionEventArgs(true, "test");
                MyAction(this, ea);
            }
        }

        //Action method
        protected void OnMyAction(object sender, MyActionEventArgs ev)
        {
            Console.WriteLine("Action: cancel {0}, message {1}", ev.Cancel, ev.Message);
        }
    }
}
