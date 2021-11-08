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
    class GameplayScene : IScene
    {
        private int Width;
        private int Height;

        public GameplayScene(int width, int height)
        {
            Width = width;
            Height = height;
        }


        public bool IsAlive()
        {
            return true;
        }

        public IScene Next()
        {
            return null;
        }


        public void ProcessInput(int deltaTime)
        {
            
        }

        public void GameUpdate(int deltaTime)
        {

        }

        public void Render(Graphics g, int deltaTime)
        {
            SokobanModel model = SokobanWindow.instance().Model;
            SokobanLevel level = model.Level;
        }
    }
}
