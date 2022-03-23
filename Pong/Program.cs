using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace Pong
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PongGame game = new PongGame(1360, 768, 30);
            game.Start();

            Application.Run();

        }
    }
}
