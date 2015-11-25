using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_DelegatesAndEvents
{
    public class MyActionEventArgs : System.ComponentModel.CancelEventArgs
    {
        public MyActionEventArgs() : this(false)
        {

        }

        public MyActionEventArgs(bool cancel): this(cancel, string.Empty)
        {

        }

        public MyActionEventArgs(bool cancel, string message) : base(cancel)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
