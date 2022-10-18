using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uEngine;
using uEngine.Managers;
using uEngine.Scenes;

namespace SceneTest
{
    public class Scene1 : uScene
    {
        private bool DownPressed;
        private bool UpPressed;
        private bool EnterPressed;


        private int ToUpKey = ((int)Keys.Up);
        private int ToDownKey = ((int)Keys.Down);

        private int Selected;
        private bool Editing;

        public void GameUpdate(int DeltaTime)
        {
        }

        public void ProcessInputs()
        {
            if (Editing == false)
            {

                if (uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Escape))
                {
                    uSceneManager.SetActive("menu");
                }

                if (uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Down))
                {
                    if (DownPressed == false)
                    {
                        DownPressed = true;
                        Selected++;
                        if (Selected >= 1)
                        {
                            Selected = 1;
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
                    if (EnterPressed == false)
                    {
                        EnterPressed = true;
                        Editing = true;
                    }
                }
                else
                {
                    EnterPressed = false;
                }

                if (Editing == true)
                {
                    Keys? pressed = uInputManager.GetKeyPressed();
                    if (pressed.HasValue)
                    {
                        switch (Selected)
                        {
                            case 0: ToUpKey = (int)pressed.Value; break;
                            case 1: ToDownKey = (int)pressed.Value; break;
                        }
                    }


                }

            }
            else
            {
                if (uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Escape))
                {
                    Editing = false;
                }
            }


        }

        public void Render(Graphics g)
        {
            g.Clear(Color.White);

            Font titleFont = uResourcesManager.GetFont("menu-font", 32);
            Font smallFont = uResourcesManager.GetFont("menu-font", 18);
            g.DrawString("Welcome to Scene 1", titleFont, new SolidBrush(Color.Black), 30, 50);
            g.DrawString("Press ESC key to go back", smallFont, new SolidBrush(Color.Black), 30, 100);

            int x = 450;
            int y = 470;
            Font menuFont = uResourcesManager.GetFont("menu-font", 24);

            Color m1 = Color.Black;
            Color m2 = Color.Black;

            switch (Selected)
            {
                case 0: m1 = Color.Blue; break;
                case 1: m2 = Color.Blue; break;
            }

            Keys down = (Keys)ToDownKey;
            Keys up = (Keys)ToUpKey;

            string textUp = ( Selected == 0 && Editing == true ) ? "<press any key>" : up.ToString();
            string textDown = ( Selected == 1 && Editing == true ) ? "<press any key>" : down.ToString();

            g.DrawString("Arriba : " + textUp, menuFont, new SolidBrush(m1), x, y);
            g.DrawString("Abajo : " + textDown, menuFont, new SolidBrush(m2), x, y + 50);


        }
    }
}
