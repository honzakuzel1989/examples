using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Diagnostics;
using System.Threading;

namespace _18_TracingAndEvents
{
    public class Test : IChapter
    {
        //Source
        private TraceSource ts = new TraceSource("tracing");

        public Test()
        {
            //Switch - turns on the switch
            ts.Switch = new SourceSwitch("MySwitch", "Verbose");

            //Listener - not working (file size is always zero)
            //DelimitedListTraceListener dtl = new DelimitedListTraceListener("DelimTrace.txt");
            //dtl.Delimiter = "\n";
            //dtl.TraceOutputOptions = TraceOptions.DateTime | TraceOptions.ProcessId;
            //ts.Listeners.Add(dtl);

            ts.TraceInformation("Test start");
            Thread.Sleep(500);
            ts.TraceInformation("Test end");
        }

        public void Run()
        {
            ts.TraceInformation("Run start");
            _1();
            //Trace error
            //_2(null);
            _2(32);
            _3();
            ts.TraceInformation("Run end");
        }

        private void _1()
        {
            ts.TraceInformation("_1 start");
            Thread.Sleep(500);
            ts.TraceInformation("_1 end");
        }

        private void _2(object o)
        {
            //Usefull in libraries, that are used by developers
            //Is possible turn on/off assertion in app configuration
            Trace.Assert(o != null);
        }

        //Admin is required
        private void _3()
        {
            //If log does not exists, will be create
            //const string source = "EventLogDemo";
            //const string eventLogName = "ProCsLog";
            //if (!EventLog.SourceExists(eventLogName))
            //{
            //    EventSourceCreationData escd = new EventSourceCreationData(source, eventLogName);
            //    EventLog.CreateEventSource(escd);
            //}

            ////Use log
            //using (EventLog log = new EventLog(eventLogName, ".", source))
            //{
            //    log.WriteEntry("Test message 1", EventLogEntryType.Warning);
            //}
        }
    }
}
