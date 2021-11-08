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

            SokobanModel model = new SokobanModel();
            model.Add("level0.txt");
            model.Add("level1.txt");


            SokobanWindow window = new SokobanWindow(model, 1024, 768, 60);
            window.Start();

            Application.Run();
        }
    }
}
