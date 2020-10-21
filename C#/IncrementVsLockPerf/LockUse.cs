namespace IncrementVsLockPerf
{
    class LockUse
    {
        private readonly object counterlock = new object();
        private int counter = 0;

        public int Value => counter;

        public void Increment()
        {
            lock (counterlock)
            {
                counter++;
            }
        }
    }
}
