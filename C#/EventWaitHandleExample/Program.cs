using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventWaitHandleExample
{
    class Program
    {
        // EventWaitHandle with EventResetMode.AutoReset is the same as AutoResetEvent 
        // (analogically with EventResetMode.ManualReset and ManualResetEvent)

        // in this example is very important initialState value.. has to be true otherwise occurs deadlock
        static EventWaitHandle are1 = new EventWaitHandle(true, EventResetMode.AutoReset, nameof(are1));
        // Auto reset events - nonsignaled state is automatically set after each WaitOne
        static EventWaitHandle are2 = new EventWaitHandle(false, EventResetMode.AutoReset, nameof(are2));

        // Manual reset event - you have to manually call Reset() for set nonsignaled state
        static EventWaitHandle done = new EventWaitHandle(false, EventResetMode.ManualReset, nameof(done));

        // the result of counter will be max + 1 (because do not check counter value directly before incrementation)
        static volatile int max = 10;
        static volatile int counter = 0;

        static void Run1()
        {
            while (counter <= max)
            {
                Console.WriteLine($"Run1: are1.WaitOne()");
                are1.WaitOne();
                counter++;
                Console.WriteLine($"Run1: {counter}");
                Thread.Sleep(500);
                are2.Set();
                Console.WriteLine($"Run1: are2.Set()");
            }

            done.Set();
            Console.WriteLine($"Run1: done.Set()");
        }

        static void Run2()
        {
            while (counter <= max)
            {
                Console.WriteLine($"Run2: are2.WaitOne()");
                are2.WaitOne();
                counter++;
                Console.WriteLine($"Run2: {counter}");
                Thread.Sleep(500);
                are1.Set();
                Console.WriteLine($"Run2: are1.Set()");
            }

            done.Set();
            Console.WriteLine($"Run2: done.Set()");
        }

        static void Main(string[] args)
        {
            Thread _1 = new Thread(new ThreadStart(Run1));
            Thread _2 = new Thread(new ThreadStart(Run2));

            _2.Start();
            _1.Start();

            // wait for done signal from _1 AND _2
            Console.WriteLine($"Main: done.WaitOne()");
            done.WaitOne();
            // imported line of code if done is ManualResetEvent, otherwise useless
            Console.WriteLine($"Main: done.Reset()");
            done.Reset();
            Console.WriteLine($"Main: done.WaitOne()");
            done.WaitOne();

            Console.WriteLine($"Press \\n to exit...");
            Console.ReadLine();
        }
    }
}
