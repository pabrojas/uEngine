using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace Selector.Scenes
{
    class Escena2 : uScene
    {

        private bool ended = false;

        public void GameUpdate(int DeltaTime)
        {
        }

        public bool IsAlive()
        {
            return !ended;
        }

        public uScene Next()
        {
            return new SelectionScene();
        }

        public void ProcessInput()
        {
            if (uInputManager.IsKeyPressed("Escape"))
            {
                ended = true;
            }
        }

        public void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1024, 738);

            g.FillRectangle(new SolidBrush(Color.FromArgb(142, 191, 40)), 0, 0, 1024, 768);
        }
    }
}
