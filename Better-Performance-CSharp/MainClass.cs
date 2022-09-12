// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;

namespace DrawSquare
{
    public class MainClass
    {
        [Benchmark]
        public static void DrawLine(int x1, int y1, int x2, int y2)
        {
            //TODO: put line drawing code here
        }
        public static void DrawSquare(int x, int y, int w, int h,object obj)
        {
            int xw = x + w;
            int yh = y + h;

            DrawLine(x, y, xw, y);
            DrawLine(xw, y, xw, yh);
            DrawLine(xw, yh, x, yh);
            DrawLine(x, yh, x, y);
        }
    }
}



