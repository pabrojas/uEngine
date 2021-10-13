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

        private List<Bullet> Bullets;


        public GalaxaintGame(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            xPlayer = 250;
            Bullets = new List<Bullet>();
        }

        public override void GameUpdate()
        {
            /*foreach (Bullet bullet in Bullets)
            {
                bullet.Y -= DeltaTime * 2.5f;

                if( bullet.Y <= 0 )
                {
                    Bullets.Remove(bullet);
                }
            }*/
            for(int i = 0; i < Bullets.Count; i++)
            {
                Bullet bullet = Bullets[i];
                bullet.Y -= DeltaTime * 2.5f;

                if (bullet.Y <= 0)
                {
                    Bullets.RemoveAt(i);
                    i--;
                }

            }

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
            if( uInputManager.IsKeyPressed("J") )
            {
                Bullet bullet = new Bullet( xPlayer + 99 * 0.6f * 0.5f, 700);
                Bullets.Add(bullet);
            }
        }

        public override void Render(Graphics g)
        {
            Image playerImage = uResourcesManager.GetImage("player");
            g.DrawImage(playerImage, xPlayer, 700, 99*0.6f, 75*0.6f);


            Image laserImage = uResourcesManager.GetImage("laser");
            foreach(Bullet bullet in Bullets)
            {
                g.DrawImage(laserImage, bullet.X, bullet.Y, 13 * 0.6f, 37 * 0.6f);
            }


        }
    }
}
