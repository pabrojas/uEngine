using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using uEngine;
using uEngine.Scenes;

namespace SceneTest
{
    public class SceneGame : uGame
    {
        public SceneGame(int windowWidth, int windowHeight, int FPS) : base(windowWidth, windowHeight, FPS)
        {
            uSceneManager.Register(new MenuScene(), "menu");
            uSceneManager.Register(new Scene1(), "scene1");
            uSceneManager.Register(new Scene2(), "scene2");
            uSceneManager.Register(new Scene3(), "scene3");
            uSceneManager.Register(new Scene4(), "scene4");
            uSceneManager.SetActive("menu");
        }
        
    }
}
