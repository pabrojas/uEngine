using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace PruebaGameObjects
{
    public class GameObjectTestScene : uScene
    {
        GameObjectTestGame Game;
        uGameObject ugo;

        public GameObjectTestScene(GameObjectTestGame game)
        {
            Game = game;
            uSingleSprite uss = new uSingleSprite(uImageManager.Get("idle"));
            ugo = new uGameObject(100, 100, 100, 100, uss);
            uBoundingBox ubb = new uBoundingBox(21, 0, 66, 100);
            ugo.Add(ubb);







            game.Add(ugo);


        }

        public void GameUpdate(int DeltaTime)
        {
        }

        public bool IsAlive()
        {
            return true;
        }

        public uScene Next()
        {
            return null;
        }

        public void ProcessInput()
        {
        }

        public void Render(Graphics g)
        {
            uBounds<double> world = new uBounds<double>(ugo.X, ugo.Y, ugo.Width, ugo.Height);
            uBounds<int> window = uConverter.Parse(world, Game.Viewport, Game.WindowWidth, Game.WindowHeight);

            g.DrawImage(ugo.Sprite.Current(), window.X, window.Y, window.Width, window.Height);


            g.DrawRectangle(new Pen(Color.White), window.X, window.Y, window.Width, window.Height);



        }
    }
}
