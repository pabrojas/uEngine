using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Sokoban.Models;
using Sokoban.Views;

using uEngine;

namespace Sokoban
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            uResourcesManager.LoadFont("Kenney Future.ttf", "fuente-menu");

            uResourcesManager.LoadImage("logo_idvrv.png", "logo-escuela");
            uResourcesManager.LoadImage("block_05.png", "wall");
            uResourcesManager.LoadImage("ground_06.png", "floor");
            uResourcesManager.LoadImage("crate_07.png", "box");
            uResourcesManager.LoadImage("crate_10.png", "box-on-goal");
            uResourcesManager.LoadImage("environment_10.png", "goal");
            uResourcesManager.LoadImage("player_05.png", "player");

            /*
            SokobanLevel level = new SokobanLevel("level1.txt");
            Console.WriteLine(level);
            */

            SokobanModel sokoban = new SokobanModel();
            sokoban.Add("level0.txt");
            sokoban.Add("level1.txt");

            SokobanGame game = new SokobanGame(sokoban, 1024, 768, 60);
            game.Start();

            Application.Run();
        }
    }
}
