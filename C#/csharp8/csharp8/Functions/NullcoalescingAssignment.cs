using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp8.Functions
{
    class NullcoalescingAssignment
    {
        public IReadOnlyList<string> Data => data;
        private List<string> data;

        public NullcoalescingAssignment() : this(default)
        {

        }

        public NullcoalescingAssignment(IEnumerable<string> inp)
        {
            data = (inp ??= GetDefault()).ToList();
        }

        private static IEnumerable<string> GetDefault()
        {
            return Enumerable.Empty<string>();
        }

        public string Add(string str)
        {
            data.Add(str ??= "<empty>");
            return str;
        }
    }
}
