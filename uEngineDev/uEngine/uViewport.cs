using System;
using System.Windows;
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


        /*
        
        P1                          P2
            +--------------------+
            |                    |
            |                    |
            |                    |
            |                    |
            +--------------------+
        P3                          P4

        */

        public bool Contains(uGameObject ugo)
        {
            Rect r1 = new Rect(X, Y, Width, Height);

            Point p1 = new Point(ugo.X, ugo.Y);
            Point p2 = new Point(ugo.X + ugo.Width, ugo.Y);
            Point p3 = new Point(ugo.X, ugo.Y + ugo.Height);
            Point p4 = new Point(ugo.X + ugo.Width, ugo.Y + ugo.Height);

            if (r1.Contains(p1) || r1.Contains(p2) || r1.Contains(p3) || r1.Contains(p4))
            {
                return true;
            }

            return false;
        }
    }
}
