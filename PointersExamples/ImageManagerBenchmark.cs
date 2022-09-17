using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Drawing;

namespace PointersExamplesImagesManipulation
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Declared)]
    [RankColumn]
    public class ImageManagerBenchmark
    {
        ImageManager _imageManager = new();
        Bitmap bmpA;
        Bitmap bmpB;
        int _sizePseudoImg = 512;

        //public ImageManagerBenchmark()
        //{
        //    bmpA = (Bitmap)Bitmap.FromFile("lenna.png");
        //    bmpB = (Bitmap)Bitmap.FromFile("lenna.png");
        //}
        //[Benchmark]
        //public void GrayScaleConversion_Without_Pointers()
        //{
            
        //    _imageManager.GrayScaleConversion_Without_Pointers(bmpA);
        //    bmpA.Save("lenna_bw_a.png");
        //}
        //[Benchmark]
        //public void GrayScaleConversion_With_Pointers()
        //{
        //    _imageManager.GrayScaleConversion_With_Pointers(bmpB);
        //    bmpB.Save("lenna_bw_b.png");
        //}
        [Benchmark]
        public void PseudoImage_GrayScaleConversion__TraditionalArray()
        {
            _imageManager.GrayScaleConversion_PseudoImage_TraditionalArray_Convert(_sizePseudoImg);
        }
        [Benchmark]
        public void PseudoImage_GrayScaleConversion_With_Pointers()
        {
            _imageManager.GrayScaleConversion_PseudoImage_PointerIndexer_Convert(_sizePseudoImg);
        }
        [Benchmark]
        public void PseudoImage_GrayScaleConversion_With_PointerArithmetic()
        {
            _imageManager.GrayScaleConversion_PseudoImage_PointerArithmetic_Convert(_sizePseudoImg);
        }
    }
}
