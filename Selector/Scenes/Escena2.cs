using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace Selector.Scenes
{
    class Escena2
    {
        private bool ended = false;

        public void Initialize()
        {
            ended = false;
        }

        public bool isEnded()
        {
            return ended;
        }

        public void GameUpdate()
        {
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
            g.FillRectangle(new SolidBrush(Color.FromArgb(142, 191, 40)), 0, 0, 1024, 768);
        }
    }
}
