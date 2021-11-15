using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public abstract class uSprite
    {
        public int Width { set; get; }
        public int Height { set; get; }

        protected uSprite(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public abstract void Update(int deltaTime);

        public abstract Image GetCurrentFrame();




    }
}
