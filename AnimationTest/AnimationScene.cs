using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace AnimationTest
{
    public class AnimationScene : uScene
    {
        private uSprite sprite;
        private int X;

        string tecla = "Right";
        bool CambiarTecla = false;

        public AnimationScene()
        {
            X = 100;
            uAnimatedSprite uas = new uAnimatedSprite(5);
            for (int i = 1; i <= 15; i++)
            {
                uas.Add(uImageManager.Get("idle" + i));
            }

            sprite = uas;
        }

        public void GameUpdate(int DeltaTime)
        {
            sprite.Update(DeltaTime);
        }

        public bool IsAlive()
        {
            return true;
        }

        public uScene Next()
        {
            return null;
        }

        public void ProcessInput()
        {

            if( uInputManager.IsMouseButtonPressed(MouseButtons.Left) )
            {
                X++;
            }



            /*
            if (uInputManager.IsKeyPressed(tecla))
            {
                X++;
            }

            if (uInputManager.IsKeyPressed("Enter"))
            {
                CambiarTecla = true;
            }
            else if(CambiarTecla == true)
            {
                List<string> telcasPresionadas = uInputManager.GetPressedKeys();
                if( telcasPresionadas.Count > 0 )
                {
                    tecla = telcasPresionadas[0];
                    CambiarTecla = false;
                }
            }
            */
        }

        public void Render(Graphics g)
        {
            //416, 454

            g.DrawImage(sprite.Current(), X, 100, 416, 454);

        }
    }
}
