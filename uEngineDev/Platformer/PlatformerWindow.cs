using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace Platformer
{
    class PlatformerWindow : uGame
    {
        private int index;
        private int time;
        private int x;

        public PlatformerWindow(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            index = 0;
            time = 0;

            x = 0;
        }

        public override void GameUpdate()
        {
            time += DeltaTime;
            if(time > 500)
            {
                time = 0;
                index++;
                if(index > 7)
                {
                    index = 0;
                }
            }
        }

        public override void ProcessInput()
        {
        }

        public override void Render(Graphics g)
        {
            Image image = null;
            switch (index)
            {
                case 0: image = uResourcesManager.GetImage("walk0"); break;
                case 1: image = uResourcesManager.GetImage("walk1"); break;
                case 2: image = uResourcesManager.GetImage("walk2"); break;
                case 3: image = uResourcesManager.GetImage("walk3"); break;
                case 4: image = uResourcesManager.GetImage("walk4"); break;
                case 5: image = uResourcesManager.GetImage("walk5"); break;
                case 6: image = uResourcesManager.GetImage("walk6"); break;
                case 7: image = uResourcesManager.GetImage("walk7"); break;
            }

            g.DrawImage(image, new Point(x, 100));


        }
    }
}
