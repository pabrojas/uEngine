using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uEngine;

namespace Selector.Scenes
{
    public class SelectionScene : uScene
    {
        private int selection;

        private bool KeyDown;
        private bool KeyUp;

        private bool ended;


        public SelectionScene()
        {
            selection = 0;
            KeyDown = false;
            KeyUp = false;

            ended = false;
        }

        public int getSelection()
        {
            return selection;
        }

        public bool IsAlive()
        {
            return !ended;
        }

        public uScene Next()
        {
            if(selection == 0)
            {
                return new Escena1();
            }

            if (selection == 1)
            {
                return new Escena2();
            }

            return new Escena3();
        }

        public void GameUpdate(int DeltaTime)
        {
            if (ended == false)
            {
                if (uInputManager.IsKeyPressed("Down"))
                {
                    if (KeyDown == false)
                    {
                        KeyDown = true;
                        selection++;
                        if (selection > 2)
                        {
                            selection = 0;
                        }
                    }
                }
                else
                {
                    KeyDown = false;
                }

                if (uInputManager.IsKeyPressed("Up"))
                {
                    if (KeyUp == false)
                    {
                        KeyUp = true;
                        selection--;
                        if (selection < 0)
                        {
                            selection = 2;
                        }
                    }
                }
                else
                {
                    KeyUp = false;
                }
            }

            if (uInputManager.IsKeyPressed("Enter"))
            {
                ended = true;
            }
        }

        public void ProcessInput()
        {
            
        }

        public void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1024, 738);

            //376, 141

            if (selection == 0)
            {
                g.DrawImage(uImageManager.Get("selected"), (1024 - 376) / 2, 100, 376, 141);
            }
            else
            {
                g.DrawImage(uImageManager.Get("normal"), (1024 - 376) / 2, 100, 376, 141);
            }


            if (selection == 1)
            {
                g.DrawImage(uImageManager.Get("selected"), (1024 - 376) / 2, 300, 376, 141);
            }
            else
            {
                g.DrawImage(uImageManager.Get("normal"), (1024 - 376) / 2, 300, 376, 141);
            }

            if (selection == 2)
            {
                g.DrawImage(uImageManager.Get("selected"), (1024 - 376) / 2, 500, 376, 141);
            }
            else
            {
                g.DrawImage(uImageManager.Get("normal"), (1024 - 376) / 2, 500, 376, 141);
            }

            g.DrawString("escena 1", uFontManager.Get("rocket", 24), new SolidBrush(Color.Black), (1024 - 376) / 2 + 60, 150);
            g.DrawString("escena 2", uFontManager.Get("rocket", 24), new SolidBrush(Color.Black), (1024 - 376) / 2 + 60, 350);
            g.DrawString("escena 3", uFontManager.Get("rocket", 24), new SolidBrush(Color.Black), (1024 - 376) / 2 + 60, 550);



        }
    }
}
