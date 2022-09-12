using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
namespace Exceptions_Performance
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class ExceptionManagerBenchmark
    {
        ExceptionManager _exceptionManager = new();

        [Benchmark]
        public void Loop_Without_Exceptions()
        {
            _exceptionManager.Loop_Without_Exceptions(100);
        }
        [Benchmark]
        public void Loop_With_Exceptions()
        {
            _exceptionManager.Loop_With_Exceptions(100);
        }
    }
}
