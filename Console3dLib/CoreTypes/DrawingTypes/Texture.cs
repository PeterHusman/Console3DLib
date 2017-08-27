using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console3dLib.CoreTypes.DrawingTypes
{
    public class Texture
    {
        public Color this[int x, int y]
        {
            get { return pixels[y, x]; }
            set { pixels[y, x] = value; }
        }

        Color[,] pixels;

        public void LoadFromFile(string path)
        {
            Bitmap b = new Bitmap(path);
            pixels = new Color[b.Height,b.Width];
            unsafe
            {
                for(int x = 0; x < b.Width; x++)
                {
                    for(int y = 0; y < b.Height; y++)
                    {
                        System.Drawing.Color c = b.GetPixel(x, y);
                        this[x, y] = Color.FromRGB(new Vector3(c.R,c.G,c.B));
                    }
                }
            }
        }

        public int Width { get { return pixels.GetLength(1); } }
        public int Height { get { return pixels.GetLength(0); } }
    }
}
