using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using uEngine.Managers;
using uEngine.Scenes;

namespace SceneTest
{
    public class MenuScene : uScene
    {
        private int Selected;
        private bool DownPressed;
        private bool UpPressed;

        public MenuScene()
        {
            Selected = 0;
            DownPressed = false;
            UpPressed = false;
        }

        public void GameUpdate(int DeltaTime)
        {
        }

        public void ProcessInputs()
        {
            if( uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Down) )
            {
                if( DownPressed == false )
                {
                    DownPressed = true;
                    Selected++;
                    if( Selected >= 4 )
                    {
                        Selected = 4;
                    }
                }
            }
            else
            {
                DownPressed = false;
            }

            if (uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Up))
            {
                if (UpPressed == false)
                {
                    UpPressed = true;
                    Selected--;
                    if (Selected <= 0)
                    {
                        Selected = 0;
                    }
                }
            }
            else
            {
                UpPressed = false;
            }

            if (uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Enter))
            {
                switch (Selected)
                {
                    case 0: uSceneManager.SetActive("scene1"); break;
                    case 1: uSceneManager.SetActive("scene2"); break;
                    case 2: uSceneManager.SetActive("scene3"); break;
                    case 3: uSceneManager.SetActive("scene4"); break;
                    case 4: Environment.Exit(0); break;
                }
            }

        }

        public void Render(Graphics g)
        {
            g.Clear(Color.White);

            Font titleFont = uResourcesManager.GetFont("menu-font", 32);
            g.DrawString("Welcome to Scene Selector", titleFont, new SolidBrush(Color.Black), 30, 50);

            Image image = uResourcesManager.GetImage("pabrojas");
            g.DrawImage(image, 100, 250, (int)(299*0.8), (int)(636*0.8));

            
            Font menuFont = uResourcesManager.GetFont("menu-font", 24);
            int x = 750;
            int y = 470;

            Color m1 = Color.Black;
            Color m2 = Color.Black;
            Color m3 = Color.Black;
            Color m4 = Color.Black;
            Color m5 = Color.Black;

            switch (Selected)
            {
                case 0: m1 = Color.Blue; break;
                case 1: m2 = Color.Blue; break;
                case 2: m3 = Color.Blue; break;
                case 3: m4 = Color.Blue; break;
                case 4: m5 = Color.Blue; break;
            }

            
            g.DrawString("Menú 1", menuFont, new SolidBrush(m1), x, y);
            g.DrawString("Menú 2", menuFont, new SolidBrush(m2), x, y + 50);
            g.DrawString("Menú 3", menuFont, new SolidBrush(m3), x, y + 100);
            g.DrawString("Menú 4", menuFont, new SolidBrush(m4), x, y + 150);
            g.DrawString("Salir", menuFont, new SolidBrush(m5), x, y + 200);

            g.DrawString("*", menuFont, new SolidBrush(Color.Blue), x - 30, y + Selected * 50);


        }
    }
}
