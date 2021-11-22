using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uViewport
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Width { set; get; }
        public double Height { set; get; }

        public uViewport(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
