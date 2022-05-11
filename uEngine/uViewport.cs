using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uViewport
    {
        public float X { set; get; }
        public float Y { set; get; }
        public float Width { set; get; }
        public float Height { set; get; }

        public uViewport(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
