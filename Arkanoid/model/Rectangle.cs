using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.model
{
    public class Rectangle
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }

        public Color Background { set; get; }
        public Color Border { set; get; }

        public Rectangle(int x, int y, int width, int height, Color background, Color border)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Background = background;
            Border = border;
        }
    }
}
