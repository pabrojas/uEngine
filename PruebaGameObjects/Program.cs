using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace PruebaGameObjects
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            uImageManager.Load("png/Idle (1).png", "idle");

            GameObjectTestGame game = new GameObjectTestGame( new uEngine.uViewport(0, 0, 800, 600), 800, 600, 60);
            game.Start();

            Application.Run();

        }
    }
}
