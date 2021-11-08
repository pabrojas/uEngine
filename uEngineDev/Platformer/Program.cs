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

            uResourcesManager.LoadImage("character_zombie_walk0.png", "walk0");
            uResourcesManager.LoadImage("character_zombie_walk1.png", "walk1");
            uResourcesManager.LoadImage("character_zombie_walk2.png", "walk2");
            uResourcesManager.LoadImage("character_zombie_walk3.png", "walk3");
            uResourcesManager.LoadImage("character_zombie_walk4.png", "walk4");
            uResourcesManager.LoadImage("character_zombie_walk5.png", "walk5");
            uResourcesManager.LoadImage("character_zombie_walk6.png", "walk6");
            uResourcesManager.LoadImage("character_zombie_walk7.png", "walk7");

            PlatformerWindow window = new PlatformerWindow(1024, 768, 60);
            window.Start();

            Application.Run();
        }
    }
}
