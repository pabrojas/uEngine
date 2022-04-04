using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uEngine;

namespace Arkanoid
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            uImageManager.Load("paddleRed.png", "pad");

            ArkanoidGame game = new ArkanoidGame(800, 600, 30);
            game.Start();

            Application.Run();
        }
    }
}
