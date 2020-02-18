using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp8.Functions
{
    interface IDefaultInterfaceMethods1
    {
        IEnumerable<int> Data { get; }

        int Count
        {
            get
            {
                int counter = 0;
                foreach (var d in Data) 
                    counter++;
                return counter;
            }
        }
    }

    interface IDefaultInterfaceMethods2
    {
        IEnumerable<int> Data 
        {
            get
            {
                return Enumerable.Range(1, 100);
            }
        }

        int Count { get; }
    }

    class DefaultInterfaceMethods1 : IDefaultInterfaceMethods1
    {
        public IEnumerable<int> Data { get; }
        public int Count { get; }

        public DefaultInterfaceMethods1(List<int> data)
        {
            Data = data;
            Count = data.Count;
        }
    }

    class DefaultInterfaceMethods2 : IDefaultInterfaceMethods1
    {
        public IEnumerable<int> Data { get; }
        //public int Count { get; }

        public DefaultInterfaceMethods2(List<int> data)
        {
            Data = data;
            //Count = data.Count;
        }
    }

    class DefaultInterfaceMethods3 : IDefaultInterfaceMethods2
    {
        public int Count { get; }

        public DefaultInterfaceMethods3()
        {
            Count = (this as IDefaultInterfaceMethods2).Data.Count();
        }
    }
}
