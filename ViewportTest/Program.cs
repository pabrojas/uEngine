using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using uEngine.Managers;

namespace ViewportTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1024 x 1024
            uResourcesManager.LoadImage("Backgrounds/backgroundForest.png", "background");
            //70 x 70
            uResourcesManager.LoadImage("Tiles/chocoCenter.png", "bottom");
            uResourcesManager.LoadImage("Tiles/chocoMid.png", "top");
            //120 x 201
            uResourcesManager.LoadImage("Players/bunny1_stand.png", "player");

            for (int i = 1; i < 17; i++)
            {
                uResourcesManager.LoadImage("Players/png/Idle (" + i + ").png", "player" + i);
            }

            for (int i = 1; i < 21; i++)
            {
                uResourcesManager.LoadImage("Players/png/Walk (" + i + ").png", "walk" + i);
            }



            ViewportGame game = new ViewportGame(800, 600, new uBounds<float>(0, 0, 800, 600), 60);

            game.Start();
            Application.Run();
        }
    }
}
