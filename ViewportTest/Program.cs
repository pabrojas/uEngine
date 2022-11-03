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
            uResourcesManager.LoadImage("white.png", "white");
            uResourcesManager.LoadImage("blue.png", "blue");
            ViewportGame game = new ViewportGame(800, 600, new uBounds<float>(0, 0, 800, 600), 60);

            game.Start();
            Application.Run();
        }
    }
}
