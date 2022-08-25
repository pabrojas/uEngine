using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Model
{
    public class Block
    {
        public Rectangle Bounds { get; set; }
        public string Background { get; set; }

        public Block(int x, int y, int width, int height, string background)
        {
            Bounds = new Rectangle(x, y, width, height);
            Background = background;
        }
    }
}
