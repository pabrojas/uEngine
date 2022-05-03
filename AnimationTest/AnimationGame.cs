using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace AnimationTest
{
    public class AnimationGame : uGame
    {
        public AnimationGame(int windowWidth, int windowHeight, int targetFPS) : base(windowWidth, windowHeight, targetFPS)
        {
            CurrentScene = new AnimationScene();
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
