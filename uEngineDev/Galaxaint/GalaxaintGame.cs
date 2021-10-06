using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using uEngine;

namespace Galaxaint
{
    public class GalaxaintGame : uGame
    {
        private int xPlayer;


        public GalaxaintGame(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            xPlayer = 250;
        }

        public override void GameUpdate()
        {

        }

        public override void ProcessInput()
        {
            int delta = (int)(0.5*DeltaTime);
            if( uInputManager.IsKeyPressed("A") )
            {
                xPlayer = xPlayer - delta;
            }
            if( uInputManager.IsKeyPressed("D") )
            {
                xPlayer = xPlayer + delta;
            }
        }

        public override void Render(Graphics g)
        {
            Image newImage = uResourcesManager.GetImage("player");
            g.DrawImage(newImage, xPlayer, 700, 99*0.6f, 75*0.6f);


        }
    }
}
