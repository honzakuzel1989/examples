using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncrementVsLockPerf
{
    public class Benchmark
    {
        private const int N = 10000;

        private readonly InterlockerUse interlockerUse = new InterlockerUse();

        [Benchmark]
        public void Interlocker()
        {
            for (int i = 0; i < N; i++)
            {
                interlockerUse.Increment();
            }
        }

        private readonly LockUse lockUse = new LockUse(); 

        [Benchmark]
        public void Lock()
        {
            for (int i = 0; i < N; i++)
            {
                lockUse.Increment();
            }
        }
    }
}
