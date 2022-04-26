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
    public class SelectionScene
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

        public void Initialize()
        {
            ended = false;
            selection = 0;
        }

        public bool isEnded()
        {
            return ended;
        }

        public int getSelection()
        {
            return selection;
        }

        public void GameUpdate()
        {
        }

        public void ProcessInput()
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

        public void Render(Graphics g)
        {
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
