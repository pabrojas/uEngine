using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Managers;
using uEngine;
using uEngine.Scenes;

namespace Connect4.Scenes
{
    public class SplashScene : uScene
    {
        private float alpha;
        private int stage;
        private long time;

        public SplashScene()
        {
            alpha = 0;
            stage = 0;
            time = 0;
        }

        public void GameUpdate(int DeltaTime)
        {
            //alpha += 0.01f;
            if (stage == 0)
            {
                time += DeltaTime;
                if (time > 100)
                {
                    stage = 1;
                    time = 0;
                }
            }
            else if (stage == 1)
            {
                time += DeltaTime;
                if (time > 10)
                {
                    alpha += 0.05f;
                    if (alpha >= 1)
                    {
                        alpha = 1;
                        stage = 2;
                        time = 0;
                    }
                    time = 0;
                }
            }
            else if (stage == 2)
            {
                time += DeltaTime;
                if (time > 500)
                {
                    stage = 3;
                    time = 0;
                }
            }
            else if (stage == 3)
            {
                time += DeltaTime;
                if (time > 10)
                {
                    alpha -= 0.05f;
                    if (alpha < 0)
                    {
                        alpha = 0;
                        stage = 4;
                        time = 0;
                    }
                    time = 0;
                }
            }
            else if (stage == 4)
            {
                time += DeltaTime;
                if (time > 200)
                {
                    uSceneManager.SetActive("GamePlay");
                }
            }

        }

        public void ProcessInputs()
        {
        }

        public void Render(Graphics g)
        {
            g.Clear(Color.White);

            System.Drawing.Image logo = uResourcesManager.GetImage("logo");

            int x = uGame.WindowWidth / 2 - logo.Width / 2;
            int y = uGame.WindowHeight / 2 - logo.Height / 2;

            //g.DrawImage(logo, x, y);

            ColorMatrix cm = new ColorMatrix();
            cm.Matrix33 = alpha;
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            g.DrawImage(logo, new Rectangle(x, y, logo.Width, logo.Height), 0, 0, logo.Width, logo.Height, GraphicsUnit.Pixel, ia);

        }
    }
}
