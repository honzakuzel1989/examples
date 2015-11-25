using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace _19_SubprocessesAndSynchronization
{
    public class Test : IChapter
    {
        #region IChapter Members

        public void Run()
        {
            //_1();
            //_2();
            //_3();
            //_4();
            //_5();
            //_6();
            //_7();
            //_8();
            //_9();
            //_10();
            //_11();
            //_12();
            //_13();
            //_14();
            //_15();
            //_16();
            //_17();
            //_18();
            //_19();
            //_20();
            //_21();
            _22();
        }

        #endregion

        private void _1()
        {
            //Synchronous call - waits two seconds
            Wait(2000);
        }

        private void _2()
        { 
            //Cyclic polling
            WaitDelegate wd = Wait;
            IAsyncResult ar = wd.BeginInvoke(2000, null, null);

            //Running
            while (!ar.IsCompleted)
            {
                Console.WriteLine("!ar.IsCompleted");
                Thread.Sleep(100);
            }
            
            //Get result
            int res = wd.EndInvoke(ar);
            Console.WriteLine(res);

            //If the main process is terminated, so subprocess is terminate too
        }

        //Global variable for example _3 - not necessery (see third parameter BeginInvoke in _3)
        //private WaitDelegate wd;

        private void _3()
        {
            WaitDelegate wd = Wait;
            //Equivalent, but parameters are seen
            //AsyncCallback ac = new AsyncCallback(WaitCallback)

            //Is properly passing delegate instance like third (object) parameter
            IAsyncResult ar = wd.BeginInvoke(1000, WaitCallback, wd);

        }

        //Callback method is call in thread of the delegate
        private void WaitCallback(IAsyncResult ar)
        {
            //Get returning value from delegate
            int res = (ar.AsyncState as WaitDelegate).EndInvoke(ar);
            Console.WriteLine(res);
        }

        private void _4()
        {
            //Probably equivalent like _2()
            WaitDelegate wd = Wait;
            IAsyncResult ar = wd.BeginInvoke(3000, null, null);

            while (ar.AsyncWaitHandle.WaitOne(50, true)) { /* waiting */ }

            int res = wd.EndInvoke(ar);

            Console.WriteLine(res);
        }

        private void _5()
        {
            WaitDelegate wd = Wait;
            //In case of one parameter is type optional
            wd.BeginInvoke(5000, (IAsyncResult ar) =>
                {
                    int res = wd.EndInvoke(ar);
                    Console.WriteLine(res);
                },
            null);
        }

        private delegate int WaitDelegate(int ms);

        int Wait(int ms)
        {
            Console.WriteLine("Wait - start");
            Thread.Sleep(ms);
            Console.WriteLine("Wait - end");
            return ms * 2;
        }

        private void _6()
        {
            //Lambda expression for thread definition
            new Thread(() =>
            {
                Console.WriteLine("Hello World from {0} which has id {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
            }
            ) { Name = "TestThread" }.Start();

            Console.WriteLine("Main thread");
            
            //Order is not guaranteed
        }

        //Data passing to the thread
        struct ThreadData
        {
            public int inum;
            public double dnum;
            public string str;
        }

        private void _7()
        {
            //Parametrized thread
            Thread t = new Thread(new ParameterizedThreadStart(ParametrizedThreadMethod));
            t.Start(new ThreadData() { inum = 3, dnum = 3.14, str = "pi" });
        }

        private void ParametrizedThreadMethod(object param)
        {
            ThreadData data = (ThreadData)param;
            Console.WriteLine("ThreadData:");
            Console.WriteLine("int:{0}, double:{1}, string:{2}", data.inum, data.dnum, data.str);
        }

        private void _8()
        { 
            //Class method like parameter
            ThreadClass tc = new ThreadClass(2, 2.71, "e");
            new Thread(tc.ThreadMain).Start();
        }

        public class ThreadClass
        { 
            public int inum;
            public double dnum;
            public string str;

            public ThreadClass(int i, double d, string s)
            {
                inum = i;
                dnum = d;
                str = s;
            }

            public void ThreadMain()
            {
                Console.WriteLine("ThreadData:");
                Console.WriteLine("int:{0}, double:{1}, string:{2}", inum, dnum, str);
            }
        }

        private void _9()
        { 
            //Application runs so long like run at least one thread (in foreground)!
            //Default IsBackground value is true (!IsBackground = IsForeground)!
            new Thread(delegate() { Console.WriteLine("Helloooo from delegate thread..."); }) {IsBackground = true }.Start();
        }

        private void _10()
        { 
            //Priority of the thread
            new Thread(() => /* Body */ 
            {
                Console.WriteLine("Hello World from thread with priority {0}", Thread.CurrentThread.Priority);
            }) 
            //Properties
            { 
                Priority = ThreadPriority.AboveNormal 
            }.Start();
        }

        private void _11()
        { 
            //After call Start method -> Thread is Unstarted
            //After sheduler allocation -> Thread is Running
            //After call Sleep method -> Thread is WaitSleepJoin
            //After call Abort method -> Thread is AbortRequested and ThreadAbortException is invoked
            //If thread is AbortRequeste so after ResetAbort thread is not longer AbortRequested (otherwise its state Aborted)
            //After call Join -> Thread is WaitSleepJoin and waiting to subthread

            Thread t = new Thread(() => 
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Subthread");
                });
            t.Start();
            //Thread -> Subthread
            //t.Join(500);
            //Subtread -> Thread
            t.Join(2000);
            Console.WriteLine("Thread");
        }

        private void _12()
        { 
            //ThreadPool
            //Dynamic thread collection
            //Is possible set minimal and maximal amount of the threads
            //In case are all thread use, new requirements wait in queue

            int worker, completion;
            ThreadPool.GetMaxThreads(out worker, out completion);
            Console.WriteLine("worker:{0}, completion:{1}", worker, completion);
            ThreadPool.GetMinThreads(out worker, out completion);
            Console.WriteLine("worker:{0}, completion:{1}", worker, completion);

            //Add to the quee
            WaitCallback wc = new System.Threading.WaitCallback(CallbackMethod);
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(wc);
            }

            //All threads i ThreadPool run in background
            //is not possible set thread that run in foreground
            //is not possible set thread name or priority
            //is recommended use threads in ThreadPool for short term activities!
        }

        private void CallbackMethod(object o)
        {
            Thread.Sleep(100);
            Console.WriteLine("thread id:{0}", Thread.CurrentThread.ManagedThreadId);
        }

        private void _13()
        {
            int numberOfThreads = 20;
            SharedState ss = new SharedState();
            Thread[] threads = new Thread[numberOfThreads];

            //Time conflict
            for (int i = 0; i < numberOfThreads; i++)
            {
                ThreadStart ts = new ThreadStart(new Task(ss).DoTheTask);
                Thread t = threads[i] = new Thread(ts);
                t.Start();
            }

            //Waiting
            for(int i=0; i<numberOfThreads;i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("sum:{0}", ss.State);
        }

        public class SharedState
        {
            public int State { get; set; }
        }

        public class Task
        {
            protected SharedState sharedState;

            public Task(SharedState ss)
            {
                sharedState = ss;
            }

            public virtual void DoTheTask()
            {
                for (int i = 0; i < 5000; i++)
                {
                    //Is possible lock only reference type
                    //Static type is possible lock using typeof(StaticType)
                    lock(sharedState)
                    { 
                        //If lock is uncomented, so this blok is safe
                        sharedState.State += 1; 
                    }
                    //Lock command is compile like monitor]
                    //lock(obj){ /*KS*/ }
                    //=>
                    //Monitor.Entry(obj); try { /*KS*/ } finally{ Monitor.Exit();}
                }
            }
        }

        private void _14()
        {
            //Interlocked class is created for simple atomic operations (++, --, swap, ...) - is very fast
            //Without example

            //WaitHandle - class waiting for signal

        }

        private void _15()
        {
            WaitDelegate wd = new WaitDelegate(Wait);
            
            IAsyncResult ar1 = wd.BeginInvoke(1000, null, null);
            IAsyncResult ar2 = wd.BeginInvoke(2000, null, null);
            IAsyncResult ar3 = wd.BeginInvoke(3000, null, null);
            IAsyncResult ar4 = wd.BeginInvoke(4000, null, null);
            IAsyncResult ar5 = wd.BeginInvoke(5000, null, null);

            //Stopwatch
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Waiting for all results
            while (!WaitHandle.WaitAll(new[] { ar1.AsyncWaitHandle, ar2.AsyncWaitHandle, ar3.AsyncWaitHandle, ar4.AsyncWaitHandle, ar5.AsyncWaitHandle }, 250, false))
            {
                Console.WriteLine("Waiting");
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            ar1 = wd.BeginInvoke(1000, null, null);
            ar2 = wd.BeginInvoke(2000, null, null);
            ar3 = wd.BeginInvoke(3000, null, null);
            ar4 = wd.BeginInvoke(4000, null, null);
            ar5 = wd.BeginInvoke(5000, null, null);

            sw.Reset();
            sw.Start();

            //Waiting for any results
            WaitHandle[] whs = new[] { ar1.AsyncWaitHandle, ar2.AsyncWaitHandle, ar3.AsyncWaitHandle, ar4.AsyncWaitHandle, ar5.AsyncWaitHandle };
            int result = WaitHandle.WaitAny(whs, 250, false);

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            //Resulted value is 258 -> weird
            Console.WriteLine(result);
        }

        private void _16()
        { 
            //Mutex allow synchronization of multiple process,
            //has one owner - only one process can allow to critical section

            //If created now is false, mutex alsready exists
            //If name is null, mutex will not share between processes
            bool createdNow;
            Mutex m = new Mutex(true, "MyMutex", out createdNow);

            //Check mutex owner
            if (!createdNow)
            {
                Console.WriteLine("Not allowed run many instance this application.");
                return;
            }

            //Waiting
            m.WaitOne();

            MessageBox.Show("Helloo");
        }

        private void _17()
        { 
            //Semaphore allow synchronization of multiple thread (semaphore is extension mutex)
            //Parameters specify number of free locks and maximal number of locks
            Semaphore sem = new Semaphore(3, 3);

            Thread[] threads = new Thread[10];
            for (int i = 0, e = threads.Length; i < e; i++)
            {
                threads[i] = new Thread(ThreadMain);
                threads[i].Name = ((10 - i) * 1000).ToString();
                threads[i].Start(sem);
            }
        }

        public void ThreadMain(object sem)
        {
            Semaphore s = (Semaphore)sem;

            try
            {
                //Lock one semaphore
                s.WaitOne();
                Console.WriteLine("lock:{0}", Thread.CurrentThread.Name);
                Thread.Sleep(int.Parse(Thread.CurrentThread.Name));
            }
            finally
            {
                s.Release();
                Console.WriteLine("release:{0}", Thread.CurrentThread.Name);
            }
        }

        public void _18()
        {
            //AutoResetEvent is synchronization resources
            //after set is ONE thread in CS
            //AutoResetEvent are = new AutoResetEvent(false);

            Thread[] tt = new Thread[5];

            //for (int i = 0; i < 5; i++)
            //{
            //    tt[i] = new Thread(ARETest);
            //    tt[i].Name = i.ToString();
            //    tt[i].Start(are);
            //}

            //are.Set();

            //Again synchronization resources
            //after set is possible executed CS several waiting thread
            ManualResetEvent mre = new ManualResetEvent(true);

            for (int i = 0; i < 5; i++)
            {
                tt[i] = new Thread(MRETest);
                tt[i].Name = i.ToString();
                tt[i].Start(mre);
            }
        }

        public void ARETest(object o)
        {
            AutoResetEvent are = (AutoResetEvent)o;
            are.WaitOne();
            Thread.Sleep((int.Parse(Thread.CurrentThread.Name.ToString())+1)*1000);
            Console.WriteLine(Thread.CurrentThread.Name);
            are.Set();
        }

        public void MRETest(object o)
        {
            ManualResetEvent mre = (ManualResetEvent)o;
            mre.WaitOne();
            Thread.Sleep((int.Parse(Thread.CurrentThread.Name.ToString()) + 1) * 1000);
            Console.WriteLine(Thread.CurrentThread.Name);
        }

        //Shared list
        private List<int> li = new List<int>();
        //SupportsRecursion allow get write lock multiple times
        private ReaderWriterLockSlim rwls = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public void _19()
        {
            //Writers and readers
            int nw = 2;
            Thread[] w = new Thread[nw];
            int nr = 2;
            Thread[] r = new Thread[nr];

            //Read
            for (int i = 0; i < nr; i++)
            {
                r[i] = new Thread(Reader);
                r[i].Name = "Reader " + i;
                r[i].Start();
            }

            //Write
            for (int i = 0; i < nw; i++)
            {
                w[i] = new Thread(Writer);
                w[i].Name = "Writer " + i;
                w[i].Start();
            }

            //This not function very good - is necessary add/repair synchronization resources
        }

        private void Reader()
        {
            while (true)
            {
                try
                {
                    while (li.Count <= 0 || !rwls.TryEnterReadLock(200))
                    {
                        Console.WriteLine("WAiting for read..");
                    }

                    //Reading
                    Console.WriteLine(li[0]);
                    li.RemoveAt(0);

                    //Simulation long term activity
                    Thread.Sleep(50);
                }
                finally
                {
                    //Release lock to read
                    rwls.ExitReadLock();
                }
            }
        }

        private void Writer()
        {
            while (true)
            {
                try
                {
                    //Waiting for write
                    while (!rwls.TryEnterWriteLock(100))
                    {
                        Console.WriteLine("Waiting for write..");
                    }

                    //Writing
                    int max = li.Count > 0 ? li.Max() : 0;
                    li.Add(max + 1);

                    //Simulation long term activity
                    Thread.Sleep(100);
                }
                finally
                {
                    //Release lock to write
                    rwls.ExitWriteLock();
                }
            }
        }

        private void _20()
        {
            TimerCallback tc = new TimerCallback(TimerTick);
            //Single tick evocation now
            System.Threading.Timer t = new System.Threading.Timer(tc, "t", 0, -1);

            //Periodical tick (every second) evocation now
            System.Threading.Timer tt = new System.Threading.Timer(tc, "tt", 0, 1000);
            Thread.Sleep(10000);

            t.Dispose();
            tt.Dispose();
        }

        private void TimerTick(object target)
        {
            Console.WriteLine("Timer {0} tick", target);
        }

        private void _21()
        {
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Start();

            Thread.Sleep(10 * 1000);
            t.Stop();

            t.Dispose();
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Timer tick {0}", e.SignalTime);
        }

        //GUI controls
        Button run, cancel;
        ProgressBar pb;
        BackgroundWorker bw;

        private void _22()
        {
            //Form
            Form f = new Form();
            f.Width = 1000;
            f.Height = 250;

            //Panel
            Panel p = new Panel();
            p.Dock = DockStyle.Bottom;
            p.Height = 25;
            f.Controls.Add(p);

            //Run btn
            run = new Button();
            run.Text = "Run Forrest";
            run.Enabled = true;
            run.Dock = DockStyle.Left;
            run.Click += new EventHandler(run_Click);
            p.Controls.Add(run);
            run.SendToBack();

            //Cancel btn
            cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Enabled = false;
            cancel.Dock = DockStyle.Right;
            cancel.Click += new EventHandler(cancel_Click);
            p.Controls.Add(cancel);
            cancel.SendToBack();

            //Progress bar btn
            pb = new ProgressBar();
            pb.Visible = true;
            pb.Minimum = 0;
            pb.Maximum = 100;
            pb.Dock = DockStyle.Fill;
            p.Controls.Add(pb);
            pb.BringToFront();

            //Worker
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);

            f.ShowDialog();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //This metod is call after ReportProgress method
            pb.Value = e.ProgressPercentage;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //This method is call after end DoWork (and in case cancellation)

            //Check cancel property
            if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }
            else
            {
                string state = (string)e.Result;
                MessageBox.Show(state);
            }

            run.Enabled = true;
            cancel.Enabled = false;
            pb.Value = 0;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //This method is executed after call RunWorkerAsync

            int sleepTime = (int)e.Argument;
            int stepSleepTime = sleepTime / pb.Maximum;

            for (int i = 1; i <= pb.Maximum; i++)
            {
                Thread.Sleep(stepSleepTime);
                bw.ReportProgress(i);

                //Cancel request
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    //Is not possible set Result in case of cancel
                    //e.Result = "Canceled";
                    return;
                }
            }

            e.Cancel = false;
            e.Result = "Finished";
        }

        void run_Click(object sender, EventArgs e)
        {
            run.Enabled = false;
            cancel.Enabled = true;
            pb.Value = 0;

            //Passing parameter to DoWork method - sleep time
            bw.RunWorkerAsync(5000);
        }

        void cancel_Click(object sender, EventArgs e)
        {
            //After call CancelAsing is set property CancellationPending from class BackgroundWorker
            bw.CancelAsync();
        }

        private void _23()
        { 
            //Creating asynchronous component with use events - page 653
        }
    }
}