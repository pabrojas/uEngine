using Sokoban.Models;
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
        private static SokobanWindow _instance;

        private IScene currentScene;
        public SokobanModel Model { private set; get; }

        public SokobanWindow(SokobanModel model, int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            SokobanWindow._instance = this;

            currentScene = new SplashScreen(width, height);
            Model = model;
        }

        public static SokobanWindow instance()
        {
            return SokobanWindow._instance;
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
