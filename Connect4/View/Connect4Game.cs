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

namespace Connect4.View
{
    public class Connect4Game : uGame
    {
        private GameScene game;
        private SplashScene splash;

        int scene;

        public Connect4Game(int windowWidth, int windowHeight, int FPS) : base(windowWidth, windowHeight, FPS)
        {
            game = new GameScene();
            splash = new SplashScene();
            scene = 0;
        }

        public override void GameUpdate()
        {
            switch (scene)
            {
                case 0: 
                    splash.GameUpdate(DeltaTime);  
                    if( splash.IsEnded() )
                    {
                        scene = 1;
                    }
                    break;
                case 1: game.GameUpdate(DeltaTime);  break;
            }
        }

        public override void ProcessInputs()
        {
            switch (scene)
            {
                case 0: splash.ProcessInputs(); break;
                case 1: game.ProcessInputs(); break;
            }
        }

        public override void Render(Graphics g)
        {
            switch (scene)
            {
                case 0: splash.Render(g); break;
                case 1: game.Render(g); break;
            }
        }
    }
}
