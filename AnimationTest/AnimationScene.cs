using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace AnimationTest
{
    public class AnimationScene : uScene
    {
        private uSprite sprite;

        public AnimationScene()
        {
            uAnimatedSprite uas = new uAnimatedSprite(10);
            for (int i = 1; i <= 15; i++)
            {
                uas.Add(uImageManager.Get("idle" + i));
            }

            sprite = uas;
        }

        public void GameUpdate(int DeltaTime)
        {
            sprite.Update(DeltaTime);
        }

        public bool IsAlive()
        {
            return true;
        }

        public uScene Next()
        {
            return null;
        }

        public void ProcessInput()
        {
        }

        public void Render(Graphics g)
        {
            //416, 454

            g.DrawImage(sprite.Current(), 100, 100, 416, 454);

        }
    }
}
