using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ArrayList_vs_List_vs_Array
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class IterableManagerBenchMark
    {
        IterableManager _iterableManager = new();

        [Benchmark]
        public void ArrayList_Test()
        {
            _iterableManager.ArrayList_Test(100);
        }

        [Benchmark]
        public void List_Test()
        {
            _iterableManager.List_Test(100);
        }

        [Benchmark]
        public void SimpleArray_Test()
        {
            _iterableManager.SimpleArray_Test(100);
        }
    }
}
