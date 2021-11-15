using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.sprites
{
    public class uSingleSprite : uSprite
    {
        private Image Sprite;

        public uSingleSprite(Image sprite, int width, int height) : base(width, height)
        {
            Sprite = sprite;
        }

        public override Image GetCurrentFrame()
        {
            return Sprite;
        }

        public override void Update(int deltaTime)
        {
        }
    }
}
