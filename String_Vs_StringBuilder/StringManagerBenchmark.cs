using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace String_Vs_StringBuilder
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class StringManagerBenchmark
    {
        StringManager _strManager = new();

        [Benchmark]
        public void StringConcatenation_1()
        {
            _strManager.StringTypeConcatenation(1);
        }

        [Benchmark]
        public void StringBuilderConcatenation_1()
        {
            _strManager.StringBuilderTypeConcatenation(1);
        }


        [Benchmark]
        public void StringConcatenation_2()
        {
            _strManager.StringTypeConcatenation(2);
        }

        [Benchmark]
        public void StringBuilderConcatenation_2()
        {
            _strManager.StringBuilderTypeConcatenation(2);
        }

        [Benchmark]
        public void StringConcatenation_3()
        {
            _strManager.StringTypeConcatenation(3);
        }

        [Benchmark]
        public void StringBuilderConcatenation_3()
        {
            _strManager.StringBuilderTypeConcatenation(3);
        }

        [Benchmark]
        public void StringConcatenation_4()
        {
            _strManager.StringTypeConcatenation(4);
        }

        [Benchmark]
        public void StringBuilderConcatenation_4()
        {
            _strManager.StringBuilderTypeConcatenation(4);
        }
        [Benchmark]
        public void StringConcatenation_5()
        {
            _strManager.StringTypeConcatenation(5);
        }

        [Benchmark]
        public void StringBuilderConcatenation_5()
        {
            _strManager.StringBuilderTypeConcatenation(5);
        }
    }
}
