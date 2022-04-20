using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace Memorice.Scenes
{
    public class NewGameScene
    {
        public void GameUpdate()
        {
        }

        public void ProcessInput(Point MouseLocation, bool isMousePressed)
        {
        }

        public void Render(Graphics g)
        {
            Font font = uFontManager.Get("blocks", 32);

            g.DrawString("Felicitaciones", font, new SolidBrush(Color.Black), 100, 100);

        }
    }
}
