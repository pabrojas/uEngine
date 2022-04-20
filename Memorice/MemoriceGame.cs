using Memorice.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

using Memorice.Controller;
using Memorice.Scenes;

namespace Memorice
{
    public class MemoriceGame : uGame
    {
        GameScene scene1;
        NewGameScene scene2;

        int status;

        public MemoriceGame(int windowWidth, int windowHeight, int targetFPS) : base(windowWidth, windowHeight, targetFPS)
        {
            scene1 = new GameScene();
            status = 1;

            scene2 = new NewGameScene();
        }

        


        public override void GameUpdate()
        {
            if (status == 1)
            {
                scene1.GameUpdate();
                if(scene1.IsFinished())
                {
                    status = 2;
                }
            }
            else if(status == 2)
            {
                scene2.GameUpdate();
            }


        }

        public override void ProcessInput()
        {
            if (status == 1)
            {
                scene1.ProcessInput(MouseLocation, isMousePressed());
            }
            else if (status == 2)
            {
                scene2.ProcessInput(MouseLocation, isMousePressed());
            }

        }

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1024, 768);

            if (status == 1)
            {
                scene1.Render(g);
            }
            else if (status == 2)
            {
                scene2.Render(g);
            }

        }
    }
}
