using System.Threading;

namespace IncrementVsLockPerf
{
    class InterlockerUse
    {
        private int counter = 0;

        public int Value => counter;

        public void Increment()
        {
            Interlocked.Increment(ref counter);
        }
    }
}
