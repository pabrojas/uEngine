using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace SokobanClases
{
    public class SokobanWindow : uGame
    {

        private IScene currentScene;

        public SokobanWindow(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            currentScene = new SplashScreen(width, height);
        }

        public override void GameUpdate()
        {
            currentScene.GameUpdate(DeltaTime);
            if (currentScene.IsAlive() == false)
            {
                currentScene = currentScene.Next();
            }
        }

        public override void ProcessInput()
        {
            currentScene.ProcessInput(DeltaTime);
        }

        public override void Render(Graphics g)
        {
            currentScene.Render(g, DeltaTime);
        }
    }
}
