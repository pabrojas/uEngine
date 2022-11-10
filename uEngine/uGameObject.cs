using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uGameObject
    {
        public uBounds<float> Bounds { set; get; }
        private uBounds<float> BBox { set; get; }

        public uSprite Sprite { set; get; }

        public uGameObject(uBounds<float> bounds, uSprite sprite)
        {
            Bounds = bounds;
            BBox = new uBounds<float>(0, 0, Bounds.Width, Bounds.Height);
            Sprite = sprite;
        }

        public uGameObject(uBounds<float> bounds, uBounds<float> bbox, uSprite sprite)
        {
            Bounds = bounds;
            BBox = bbox;
            Sprite = sprite;
        }

        public uBounds<float> BoundingBox()
        {
            return new uBounds<float>(Bounds.X + BBox.X, Bounds.Y + BBox.Y, BBox.Width, BBox.Height);
        }
    }
}
