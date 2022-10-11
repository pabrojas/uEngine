using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;
using uEngine.Managers;
using uEngine.Scenes;

namespace SceneTest
{
    public class Scene4 : uScene
    {
        public void GameUpdate(int DeltaTime)
        {
        }

        public void ProcessInputs()
        {
            if(uInputManager.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                uSceneManager.SetActive("menu");
            }
        }

        public void Render(Graphics g)
        {
            g.Clear(Color.White);

            Font titleFont = uResourcesManager.GetFont("menu-font", 32);
            Font smallFont = uResourcesManager.GetFont("menu-font", 18);
            g.DrawString("Welcome to Scene 4", titleFont, new SolidBrush(Color.Black), 30, 50);
            g.DrawString("Press ESC key to go back", smallFont, new SolidBrush(Color.Black), 30, 100);
        }
    }
}
