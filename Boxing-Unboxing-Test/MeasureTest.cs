using System.Diagnostics;

namespace Boxing_Unboxing_Test
{
    public class MeasureTest
    {
        private const int arraySize = 100000;
        public static long MeasureA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int a = 1;
            for (int i = 0; i < arraySize; i++)
            {
                a = a + 1;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public static long MeasureB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            object a = 1;
            for (int i = 0; i < arraySize; i++)
            {
                a = (int)a + 1;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
