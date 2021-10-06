using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using uEngine;


namespace Galaxaint
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            uResourcesManager.LoadImage("playerShip1_blue.png", "player");


            GalaxaintGame game = new GalaxaintGame(600, 800, 60);
            game.Start();
            Application.Run();
        }
    }
}
