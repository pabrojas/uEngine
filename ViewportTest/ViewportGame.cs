using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using uEngine.Scenes;

namespace ViewportTest
{
    public class ViewportGame : uGame
    {
        public ViewportGame(int windowWidth, int windowHeight, uBounds<float> viewport, int FPS) : base(windowWidth, windowHeight, viewport, FPS)
        {
            uSceneManager.Register(new ViewportScene(), "scene");
            uSceneManager.SetActive("scene");
                
        }
    }
}
