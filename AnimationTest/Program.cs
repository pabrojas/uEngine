using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;

namespace AnimationTest
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 1; i <= 15; i++)
            {
                uImageManager.Load("Idle (" + i +").png", "idle" + i);
            }



            AnimationGame game = new AnimationGame(1024, 768, 30);
            game.Start();

            Application.Run();
        }
    }
}
