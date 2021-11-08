using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace SokobanClases
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            uResourcesManager.LoadFont("Kenney Future.ttf", "fuente-menu");
            uResourcesManager.LoadImage("logo_idvrv.png", "logo-escuela");


            SokobanWindow window = new SokobanWindow(1024, 768, 60);
            window.Start();

            Application.Run();
        }
    }
}
