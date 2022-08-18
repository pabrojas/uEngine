using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PongGame game = new PongGame(1024, 768, 30);
            game.Start();


            Application.Run();
        }
    }
}
