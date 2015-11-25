using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace _12_MemoryManagmentAndPointers
{
    public class Test : IChapter, IDisposable
    {
        //Usafe global variable
        unsafe int* _ip;

        /*
         * The variable used to implementation disposing object using constructor and the metod Dispose. 
         */
        private bool isDisposed = false;

        #region IChapter Members

        public void Run()
        {
            Console.WriteLine("Chapter twelve - Memory managment and pointers.");
            Console.WriteLine("===============================================");

            _1();
            _2();
            _3(10);
        }

        private void _1()
        {
            int i = 10;
            Console.WriteLine("i:{0}",i);

            //Unsafe code - necessarily for pointers
            //This code is not controlled CLR
            unsafe
            {
                _ip = &i;
                int* ip = _ip;
                Console.WriteLine("*ip:{0}",*ip);
                Console.WriteLine("i:{0}", i);
                *ip = 20;
                Console.WriteLine("*_ip:{0}",*_ip);
                Console.WriteLine("i:{0}", i);

                //The array of the pointers to the int
                int*[] pis = new int*[] { _ip, ip };
                foreach (int *l in pis)
                {
                    Console.WriteLine(*l);
                }
            }
        }

        private void _2()
        {
            uint ui = 4000000000;
            int i = (int)ui;

            Console.WriteLine("ui:{0}", ui);
            Console.WriteLine("ui:{0}", i);
        }

        private void _3(int size)
        { 
            //High performance array
            unsafe
            {
                //Data type must be value (int, short, double, ..)
                int* iarray = stackalloc int[size];

                for (int i = 0; i < size;i++)
                {
                    //The syntax p[X] always intepreted like *(p+X)
                    int* item = &(iarray[i]);
                    Console.WriteLine("item[{0}]:{1}", i, *item);
                    *item = i;
                    Console.WriteLine("item[{0}]:{1}", i, *item);
                }
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Console.WriteLine("Dispose()");
            /*
             * Release all unmanaged resources and calling Dispose() method for all of the encapsulation objects.
             */
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        /*
         * Override Dispose() method. Parametr disposing indicates whether was method call by destructor or by Dispose().
         */
        protected void Dispose(bool disposing)
        {
            Console.WriteLine("Dispose(bool)");
            if (!isDisposed)
            {
                //From Dispose() - dispose all managed object by calling Dispose().
                if (disposing)
                { 
                    //...
                }
                //From Dispose and ~Constructor - dispose all unmanaged object by calling Dispose().
                /*
                 * Unmanaged objects:
                 * open files
                 * open network connections
                 * unmanaged memory
                 * some stuff from XNA
                 */
            }
            //!!
            isDisposed = true;
        }

        //Destructor have not return type, parameters or modificators.
        //Compiler automatically convert destructor to Finalize() method.
        //Also run Finalize() method of the parent and put destructors code to the try block.
        //Example bellow..
        ~Test()
        {
            Console.WriteLine("~Test()");
            /*
             * myObject.Delete(); 
             * ...
             * try { myObject.Delete(); }
             * finally { base.Finalize(); }
             */

            /* !! Destructors in C# have not deterministic behavior, order and to slow garbage collection !! */
            /* !! The solution of this problems is IDisposable interface with method Dispose !!*/
            Dispose(false);
        }

        /**
         * For each method is properly check if the object was not disposed.
         */
        private void SomeMethod()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("msg");
            }

            //Do something...
        }
    }
}
