using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uBounds<T>
    {
        public T X { set; get; }
        public T Y { set; get; }
        public T Width { set; get; }
        public T Height { set; get; }

        public uBounds(T x, T y, T width, T height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }


    }
}
