using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace Sokoban.Views
{
    public class MenuScreen
    {
        private int Width;
        private int Height;

        private bool alive;
        private int selected;

        private bool keyUpPressed;
        private bool keyDownPressed;

        public MenuScreen(int width, int height)
        {
            Width = width;
            Height = height;

            alive = true;
            selected = 0;
            keyUpPressed = false;
            keyDownPressed = false;
        }

        public bool IsAlive()
        {
            return alive;
        }

        public void Restart()
        {
            alive = true;
            selected = 0;
            keyUpPressed = false;
            keyDownPressed = false;
        }

        public Screen GetNextScreen()
        {
            switch(selected)
            {
                case 0: return Screen.Game;
                case 1: return Screen.HowToPlay;
                case 2: return Screen.Credits;
                case 3: return Screen.Exit;
            }
            return Screen.None;
        }

        public void ProcessInput()
        {
            if (uInputManager.IsKeyPressed("Up"))
            {
                if (keyUpPressed == false)
                {
                    keyUpPressed = true;
                    selected--;
                    if (selected < 0) selected = 0;
                }
            }
            else
            {
                keyUpPressed = false;
            }

            if (uInputManager.IsKeyPressed("Down"))
            {
                if (keyDownPressed == false)
                {
                    keyDownPressed = true;
                    selected++;
                    if (selected > 3) selected = 3;
                }
            }
            else
            {
                keyDownPressed = false;
            }

            if (uInputManager.IsKeyPressed("Enter"))
            {
                alive = false;
            }
            

        }

        public void GameUpdate(int deltaTime)
        {
        }

        public void Render(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, Width, Height);

            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(2, 57, 64));
            SolidBrush menuBrush = new SolidBrush(Color.FromArgb(32, 164, 243));


            Font fontTitle = uResourcesManager.GetFont("fuente-menu", 48);
            Font fontDescription = uResourcesManager.GetFont("fuente-menu", 22);

            Font fontMenu = uResourcesManager.GetFont("fuente-menu", 18);

            g.DrawString("Welcome to", fontDescription, drawBrush, new PointF(85, 80));
            g.DrawString("Sokoban", fontTitle, drawBrush, new PointF(80, 100));
            g.DrawString("(use arrows & enter to navigate)", fontMenu, drawBrush, new PointF(85, 160));

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;

            g.DrawString("Start", fontMenu, selected == 0 ? menuBrush : drawBrush, new PointF(Width - 100, 560), format);
            g.DrawString("How to play", fontMenu, selected == 1 ? menuBrush : drawBrush, new PointF(Width - 100, 585), format);
            g.DrawString("Credits", fontMenu, selected == 2 ? menuBrush : drawBrush, new PointF(Width - 100, 610), format);
            g.DrawString("Exit", fontMenu, selected == 3 ? menuBrush : drawBrush, new PointF(Width - 100, 635), format);

            g.DrawString("*", fontDescription, menuBrush, new PointF(Width - 100, 560 + 25 * selected));

        }

    }
}
