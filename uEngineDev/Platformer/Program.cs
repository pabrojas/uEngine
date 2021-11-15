using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uEngine;

namespace Platformer
{
    class Program
    {
        static void Main(string[] args)
        {
            uResourcesManager.LoadImage("backgroundForest.png", "background");
            uResourcesManager.LoadImage("slice03_03.png", "ground");


            for (int i = 1; i <= 16; i++)
            {
                uResourcesManager.LoadImage("Idle (" + i +").png", "idle" + i);
            }

            for (int i = 1; i <= 20; i++)
            {
                uResourcesManager.LoadImage("Walk (" + i + ").png", "walk" + i);
            }

            for (int i = 1; i <= 20; i++)
            {
                uResourcesManager.LoadImage("Run (" + i + ").png", "run" + i);
            }



            PlatformerWindow window = new PlatformerWindow(1024, 768, 60);
            window.Start();

            Application.Run();
        }
    }
}
