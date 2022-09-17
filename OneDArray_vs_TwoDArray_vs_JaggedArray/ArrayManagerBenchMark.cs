using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace OneDArray_vs_TwoDArray_vs_JaggedArray
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class ArrayManagerBenchMark
    {
        ArrayManager _arrayManager = new();

        [Benchmark]
        public void One_Dimensional_Array()
        {
            _arrayManager.One_Dimensional_Array(100);
        }
        [Benchmark]
        public void Two_Dimensional_Array()
        {
            _arrayManager.Two_Dimensional_Array(100);
        }
        [Benchmark]
        public void JaggedArray()
        {
            _arrayManager.JaggedArray(100);
        }
        [Benchmark]
        public void SimpleArray()
        {
            _arrayManager.SimpleArray(100);
        }
        [Benchmark]
        public void PointerArray()
        {
            _arrayManager.PointerArray(100);
        }
    }
}
