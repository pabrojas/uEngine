using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxaint
{
    class Bullet
    {
        public float X { set; get; }
        public float Y { set; get; }

        public Bullet(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
