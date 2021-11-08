using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;
using Sokoban.Models;

namespace SokobanClases
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

            SokobanModel model = new SokobanModel();
            model.Add("level0.txt");
            model.Add("level1.txt");


            SokobanWindow window = new SokobanWindow(model, 1024, 768, 60);
            window.Start();

            Application.Run();
        }
    }
}
