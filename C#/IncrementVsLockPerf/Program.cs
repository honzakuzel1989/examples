using BenchmarkDotNet.Running;

namespace IncrementVsLockPerf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}
