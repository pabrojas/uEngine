using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace SokobanClases
{
    class MainMenu : IScene
    {
        private int Width;
        private int Height;

        private bool alive;
        private int selected;

        private bool keyUpPressed;
        private bool keyDownPressed;

        public MainMenu(int width, int height)
        {
            Width = width;
            Height = height;

            alive = true;
            selected = 2;
            keyUpPressed = false;
            keyDownPressed = false;
        }

        public void GameUpdate(int deltaTime)
        {
        }

        public void ProcessInput(int deltaTime)
        {
            if(alive == false)
            {
                return;
            }

            if( uInputManager.IsKeyPressed("Enter") )
            {
                alive = false;
                return;
            }

            if( uInputManager.IsKeyPressed("Up") )
            {
                if ( keyUpPressed == false )
                {
                    keyUpPressed = true;
                    selected--;
                    if (selected < 0)
                    {
                        selected = 0;
                    }
                }
            }
            else
            {
                keyUpPressed = false;
            }


            if( uInputManager.IsKeyPressed("Down") )
            {
                if (keyDownPressed == false)
                {
                    keyDownPressed = true;
                    selected++;
                    if (selected > 3)
                    {
                        selected = 3;
                    }
                }
            }
            else
            {
                keyDownPressed = false;
            }



        }

        public void Render(Graphics g, int deltaTime)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, Width, Height);

            SolidBrush regularBrush = new SolidBrush(Color.FromArgb(2, 57, 64));
            SolidBrush selectedBrush = new SolidBrush(Color.FromArgb(32, 164, 243));


            Font fontTitle = uResourcesManager.GetFont("fuente-menu", 48);
            Font fontDescription = uResourcesManager.GetFont("fuente-menu", 22);

            Font fontMenu = uResourcesManager.GetFont("fuente-menu", 18);

            g.DrawString("Welcome to", fontDescription, regularBrush, new PointF(85, 80));
            g.DrawString("Sokoban", fontTitle, regularBrush, new PointF(80, 100));
            g.DrawString("(use arrows & enter to navigate)", fontMenu, regularBrush, new PointF(85, 160));

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;

            g.DrawString(
                "Start", 
                fontMenu, 
                selected == 0 ? selectedBrush : regularBrush, 
                new PointF(Width - 100, 560), 
                format);
            
            g.DrawString("How to play", fontMenu, selected == 1 ? selectedBrush : regularBrush, new PointF(Width - 100, 585), format);
            g.DrawString("Credits", fontMenu, selected == 2 ? selectedBrush : regularBrush, new PointF(Width - 100, 610), format);
            g.DrawString("Exit", fontMenu, selected == 3 ? selectedBrush : regularBrush, new PointF(Width - 100, 635), format);

            g.DrawString("*", fontDescription, selectedBrush, new PointF(Width - 100, 560 + 25 * selected));
        }


        public bool IsAlive()
        {
            return alive;
        }

        public IScene Next()
        {
            if( selected == 0 )
            {
                return new GameplayScene(Width, Height);
            }
            else if (selected == 1)
            {
                //return HowToPlay();
            }
            else if (selected == 2)
            {
                //return Credits();
            }
            else if(selected == 3)
            {
                //return Exit();
            }
            return null;
        }
    }
}
