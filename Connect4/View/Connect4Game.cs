using Connect4.Model;
using Connect4.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uEngine;
using uEngine.Managers;
using uEngine.Scenes;

namespace Connect4.View
{
    public class Connect4Game : uGame
    {
        public Connect4Game(int windowWidth, int windowHeight, int FPS) : base(windowWidth, windowHeight, FPS)
        {
            uSceneManager.Register(new GameScene(), "GamePlay");
            uSceneManager.Register(new SplashScene(), "SplashScreen");
            uSceneManager.Register(new FinishScene(), "Ending");

            uSceneManager.SetActive("SplashScreen");
        }

        public override void GameUpdate()
        {
            uSceneManager.GetActive().GameUpdate(DeltaTime);
        }

        public override void ProcessInputs()
        {
            uSceneManager.GetActive().ProcessInputs();
        }

        public override void Render(Graphics g)
        {
            uSceneManager.GetActive().Render(g);
        }
    }
}
