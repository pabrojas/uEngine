using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uWindowObject
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }

        public uWindowObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public static uWindowObject Parse(uGameObject ugo, uViewport vp, double xRatio, double yRatio)
        {
            double xUgo = ugo.X;
            double yUgo = ugo.Y;
            double wUgo = ugo.Width;
            double hUgo = ugo.Height;

            int offsetX = (int)Math.Round(vp.X * xRatio);
            int offsetY = (int)Math.Round(vp.Y * yRatio);

            int xUwo = (int)Math.Round(xUgo * xRatio) - offsetX;
            int yUwo = (int)Math.Round(yUgo * yRatio) - offsetY;
            int wUwo = (int)Math.Round(wUgo * xRatio);
            int hUwo = (int)Math.Round(hUgo * yRatio);

            return new uWindowObject(xUwo - 1, yUwo - 1, wUwo + 1, hUwo + 1);
        }

    }
}
