using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public enum Direction
    {
        Left, Right, Up, Down
    }

    public class uGameObject
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Width { set; get; }
        public double Height { set; get; }
        public uSprite Sprite { set; get; }
        public Direction Facing { set; get; }

        public uGameObject(double x, double y, double width, double height, uSprite sprite)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Sprite = sprite;
            Facing = Direction.Right;
        }

        public void Update(int deltaTime)
        {
            Sprite.Update(deltaTime);
        }



    }
}
