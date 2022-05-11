using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using Selector.Scenes;

namespace Selector
{
    public class SelectorGame : uGame
    {
        public SelectorGame(uViewport viewport, int windowWidth, int windowHeight, int targetFPS) : base(viewport, windowWidth, windowHeight, targetFPS)
        {
            CurrentScene = new SelectionScene();
        }

        public override void GameUpdate(int DeltaTime)
        {
            CurrentScene.GameUpdate(DeltaTime);
        }

        public override void ProcessInput()
        {
            CurrentScene.ProcessInput();
        }

    }
}
