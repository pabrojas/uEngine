using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public enum Direction
    {
        Left, Right
    }

    public class uGameObject
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public uSprite Sprite { set; get; }
        public Direction Facing { set; get; }

        public uGameObject(int x, int y, int width, int height, uSprite sprite)
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
