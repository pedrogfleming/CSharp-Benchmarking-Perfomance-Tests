using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointersExamplesImagesManipulation
{
    public class ImageManager
    {
        public void GrayScaleConversion_Without_Pointers(Bitmap bmp)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte grey = (byte)(
                        .299 * pixel.R + .587 * pixel.G + .144 * pixel.B);
                    Color greyPixel = Color.FromArgb(grey, grey, grey);
                    bmp.SetPixel(x, y, greyPixel);
                }
            }
        }
        public void GrayScaleConversion_With_Pointers(Bitmap bmp)
        {
            //Request access to the raw image data
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    //This is the GrayScale formula
                    //It use an indexir to obtain the red, green ,blue values
                    //writing repeatdly at the current address and advancing the pointer 1 address by
                    byte pixel = (byte)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                    *p = pixel;
                    p++;
                    *p = pixel;
                    p++;
                    *p = pixel;
                    p++;
                }
                bmp.UnlockBits(bmData);
            }
        }
        public void GrayScaleConversion_PseudoImage_TraditionalArray_Convert(int size)
        {
            byte[] image = new byte[size * size * 3];
            for (int k = 512; k < 4096; k += 128)
            {
                for (int i = 0; i < image.Length; i++)
                {
                    byte grey = (byte)(.299 * image[i + 2] + .587 * image[i + 1] + .114 * image[i]);
                    image[i] = grey;
                    image[i + 1] = grey;
                    image[i + 2] = grey;
                    i += 3;
                }
            }
        }
        public void GrayScaleConversion_PseudoImage_PointerIndexer_Convert(int size)
        {
            byte[] image = new byte[size * size * 3];
            for (int k = 512; k < 4096; k += 128)
            {
                unsafe
                {
                    fixed (byte* p = &image[0])
                    {
                        for (int i = 0; i < image.Length;)
                        {
                            byte grey = (byte)(.299 * image[i + 2] + .587 * image[i + 1] + .114 * image[i]);
                            p[i] = grey;
                            p[i + 1] = grey;
                            p[i + 2] = grey;
                            i += 3;
                        }
                    }
                }
            }
        }
        public void GrayScaleConversion_PseudoImage_PointerArithmetic_Convert(int size)
        {
            byte[] image = new byte[size * size * 3];
            for (int k = 512; k < 4096; k += 128)
            {
                unsafe
                {
                    fixed (byte* imgPtr = &image[0])
                    {
                        byte* p = imgPtr;
                        int stopAddress = (int)p + size * size * 3;
                        while ((int)p != stopAddress)
                        {
                            byte grey = (byte)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                            *p = grey;
                            *(p + 1) = grey;
                            *(p + 2) = grey;
                            p += 3;
                        }
                    }
                }
            }
        }
    }
}
