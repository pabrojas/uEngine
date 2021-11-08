using Sokoban.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace Sokoban.Views
{
    public enum Screen { None, Splash, Menu, Game, HowToPlay, Credits, Exit }

    public class SokobanGame : uGame
    {
        private int Width;
        private int Height;

        private SokobanModel Model;

        private Screen screen;

        private SplashScreen splashScreen; //1
        private MenuScreen menuScreen; //2
        private GameplayScreen gameplayScreen; //5

        

        public SokobanGame(SokobanModel model, int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            Model = model;
            Width = width;
            Height = height;

            screen = Screen.Splash;
            
            splashScreen = new SplashScreen(width, height);
            menuScreen = new MenuScreen(width, height);
            gameplayScreen = new GameplayScreen(Model, width, height);


        }

        public override void GameUpdate()
        {
            if (screen == Screen.Splash)
            {
                if (splashScreen.StillDrawing())
                {
                    splashScreen.GameUpdate(DeltaTime);
                }
                else
                {
                    screen = Screen.Menu;
                }
            }
            else if (screen == Screen.Menu)
            {
                menuScreen.GameUpdate(DeltaTime);
            }
            else if (screen == Screen.Game)
            {
                gameplayScreen.GameUpdate(DeltaTime);
            }
        }

        public override void ProcessInput()
        {
            if (screen == Screen.Splash)
            {
                splashScreen.ProcessInput();
            }
            else if (screen == Screen.Menu)
            {
                menuScreen.ProcessInput();
                if(!menuScreen.IsAlive())
                {
                    Screen next = menuScreen.GetNextScreen();
                    switch(next)
                    {
                        case Screen.Exit: 
                            Environment.Exit(0); 
                            break;
                        case Screen.Game:
                            screen = next;
                            break;
                        case Screen.HowToPlay:

                            break;
                        case Screen.Credits:

                            break;
                        default:
                            menuScreen.Restart();
                            break;

                    }
                    

                }
            }
            else if (screen == Screen.Game)
            {
                gameplayScreen.ProcessInput();
            }
        }

        public override void Render(Graphics g)
        {
            if (screen == Screen.Splash)
            {
                splashScreen.Render(g);
            }
            else if (screen == Screen.Menu)
            {
                menuScreen.Render(g);
            }
            else if (screen == Screen.Game)
            {
                gameplayScreen.Render(g);
            }
        }
    }
}
