using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace SokobanClases
{
    public class SplashScreen : IScene
    {
        private int Width;
        private int Height;

        private long time;
        private int stage;
        private float transparency;

        public SplashScreen(int width, int height)
        {
            Width = width;
            Height = height;

            time = 0;
            stage = 0;
            transparency = 0f;
        }

        public void GameUpdate(int deltaTime)
        {
            time += deltaTime;
            if (stage == 0)
            {
                if (time >= 10)
                {
                    time = 0;
                    transparency += 0.04f;
                    if (transparency > 1)
                    {
                        transparency = 1f;
                        stage = 1;
                    }
                }
            }
            else if (stage == 1)
            {
                if (time > 2000)
                {
                    time = 0;
                    stage = 2;
                }
            }
            else if (stage == 2)
            {
                if (time >= 10)
                {
                    time = 0;
                    transparency -= 0.04f;
                    if (transparency < 0)
                    {
                        transparency = 0f;
                        stage = 3;
                    }
                }
            }
            else if (stage == 3)
            {
                if (time > 500)
                {
                    stage = 4;
                }
            }
        }

        public void ProcessInput(int deltaTime)
        {
        }

        public void Render(Graphics g, int deltaTime)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, Width, Height);
            Image logo = uResourcesManager.GetImage("logo-escuela");
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix33 = transparency;
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            g.DrawImage(logo,
                new Rectangle((int)(Width * 0.25f), (int)(Height * 0.25f), (int)(Width * 0.5f), (int)(Height * 0.5f)),
                0, 0, logo.Width, logo.Height,
                GraphicsUnit.Pixel,
                ia);
        }

        public bool IsAlive()
        {
            return (stage < 4);
        }

        public IScene Next()
        {
            return new MainMenu(Width, Height);
        }
    }
}
