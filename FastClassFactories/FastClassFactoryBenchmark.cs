using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FastClassFactories
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class FastClassFactoryBenchmark
    {
        public const int REPETITIONS = 1000000;
        FastClassFactory _factory = new(REPETITIONS);

        [Benchmark(Baseline =true)]
        public void UsingSwitch()
        {
            _factory.CompileTime_Construction("System.Text.StringBuilder");
        }

        [Benchmark]
        public void UsingReflection()
        {
            _factory.Dynamic_Construction("System.Text.StringBuilder");
        }
        [Benchmark]
        public void UsingClassCreator()
        {
            _factory.CIL_Method_Construction("System.Text.StringBuilder");
        }
    }
}
