using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.Diagnostics.Runtime;
using Microsoft.Diagnostics.Tracing;

namespace Delegates_vs_Method_Calls
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class DelegateManagerBenchmark
    {
        public const int REPETITIONS = 100000;
        public const int EXPERIMENTS = 100;

        public delegate void AddDelegate(int a, int b, out int result);

        public void Add1(int a,int b,out int result)
        {
            result = a+b;
        }
        public void Add2(int a, int b, out int result)
        {
            result = a + b;
        }
        [Benchmark]
        public void Call_Method()
        {
            int result = 0;
            for (int i = 0; i < REPETITIONS; i++)
            {
                Add1(1234, 2345, out result);
                Add2(1234, 2345, out result);
            }
        }
        [Benchmark]
        public void Call_Unicast_Delegates()
        {
            int result = 0;
            AddDelegate del_Add1 = Add1;
            AddDelegate del_Add2 = Add2;
            for (int i = 0; i < REPETITIONS; i++)
            {
                del_Add1(1234, 2345, out result);
                del_Add2(1234, 2345, out result);
            }
        }
        [Benchmark]
        public void Call_Multicast_Delegate()
        {
            int result = 0;
            AddDelegate del_multiAdd = Add1;
            del_multiAdd += Add2;
            for (int i = 0; i < REPETITIONS; i++)
            {
                del_multiAdd(1234, 2345, out result);
            }
        }
    }
}
