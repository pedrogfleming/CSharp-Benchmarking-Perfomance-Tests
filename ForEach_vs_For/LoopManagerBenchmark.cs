using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ForEach_vs_For
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class LoopManagerBenchmark
    {
        public const int numElements = 1000;
        public LoopManager _loopManager = new(numElements);
        
        [Benchmark]
        public void For_Loop_ArrayList()
        {
            _loopManager.For_Loop_ArrayList();
        }
        [Benchmark]
        public void ForEach_Loop_ArrayList()
        {
            _loopManager.ForEach_Loop_ArrayList();
        }
        [Benchmark]
        public void For_Loop_GenericList()
        {
            _loopManager.For_Loop_GenericList();
        }
        [Benchmark]
        public void ForEach_Loop_GenericLis()
        {
            _loopManager.ForEach_Loop_GenericLis();
        }
        [Benchmark]
        public void For_Loop_SimpleArray()
        {
            _loopManager.For_Loop_SimpleArray();
        }
        [Benchmark]
        public void ForEach_Loop_SimpleArray()
        {
            _loopManager.ForEach_Loop_SimpleArray();
        }
    }
}
