using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using uEngine;

namespace Selector
{
    class Program
    {
        static void Main(string[] args)
        {
            uImageManager.Load("normal.png", "normal");
            uImageManager.Load("selected.png", "selected");

            uFontManager.Load("Kenney Rocket.ttf", "rocket");

            SelectorGame game = new SelectorGame(new uViewport(400, 400, 800, 600), 1024, 768, 30);
            game.Start();

            Application.Run();
        }
    }
}
