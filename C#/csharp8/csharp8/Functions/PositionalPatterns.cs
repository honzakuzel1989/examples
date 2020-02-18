using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp8.Functions
{
    class PositionalPatterns<T>
    {
        public T Head { get; }
        public T[] Tail { get; }

        public PositionalPatterns(IEnumerable<T> data) => (Head, Tail) = (data.FirstOrDefault(), Tail = data.Skip(1).ToArray());
        public void Deconstruct(out T head, out IEnumerable<T> tail) => (head, tail) = (Head, Tail);
    }
}
