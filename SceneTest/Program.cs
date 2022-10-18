using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Managers;
using uEngine;

namespace SceneTest
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            uResourcesManager.LoadFont("Kenney Blocks.ttf", "title-font");
            uResourcesManager.LoadFont("Kenney Future.ttf", "menu-font");
            uResourcesManager.LoadFont("Kenney Mini.ttf", "mini");
            uResourcesManager.LoadFont("Kenney Rocket.ttf", "rocket");

            uResourcesManager.LoadImage("pabrojas.png", "pabrojas");

            uGame game = new SceneGame(1024, 768, 30);
            game.Start();
            Application.Run();
        }
    }
}
