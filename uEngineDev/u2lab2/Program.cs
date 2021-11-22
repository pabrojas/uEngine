using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace u2lab2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            uResourcesManager.LoadImage("Blue/characterBlue (2).png", "player");
            uResourcesManager.LoadImage("Equipment/ball_soccer2.png", "soccer");

            GameWindow window = new GameWindow(1024, 768, 60);
            window.Start();

            Application.Run();

        }
    }
}
