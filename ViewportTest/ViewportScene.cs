using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using uEngine.Managers;

namespace ViewportTest
{
    public class ViewportScene : uScene
    {
        public void GameUpdate(int DeltaTime)
        {
            uGame.Viewport.Width += 1.1f;
            uGame.Viewport.Height += 1.1f;
        }

        public void ProcessInputs()
        {
        }

        public void Render(Graphics g)
        {
            Image image = uResourcesManager.GetImage("white");
            uBounds<float> mundo = new uBounds<float>(100, 100, 100, 100);
            uBounds<int> ventana = uConverter.Parse(mundo);
            g.DrawImage(image, ventana.X, ventana.Y, ventana.Width, ventana.Height);

            image = uResourcesManager.GetImage("blue");
            mundo = new uBounds<float>(199, 100, 100, 100);
            ventana = uConverter.Parse(mundo);
            g.DrawImage(image, ventana.X, ventana.Y, ventana.Width, ventana.Height);
        }
    }
}
