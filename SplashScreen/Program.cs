using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Managers;

namespace SplashScreen
{
    public class Program
    { 

        [STAThread]
        static void Main(string[] args)
        {
            uResourcesManager.LoadImage("logo.png", "logo");


            MyGame game = new MyGame(1300, 900, 60);
            game.Start();

            Application.Run();

        }
    }
}
