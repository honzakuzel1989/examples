using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex1
{
    class SubjectA : Subject
    {
        public int Value { get; private set; }

        public void SetValue(int value)
        {
            Value = value;
            Notify();
        }
    }
}
