using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using uEngine;
using uEngine.Exceptions;

namespace Galaxaint
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            try
            {
                uResourcesManager.LoadImage("playerShip1_blue.png", "player");
                uResourcesManager.LoadImage("laserBlue02.png", "laser");
            }
            catch(uResourceNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            catch(uResourceIdDuplicatedException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }


            GalaxaintGame game = new GalaxaintGame(600, 800, 60);
            game.Start();
            Application.Run();
        }
    }
}
