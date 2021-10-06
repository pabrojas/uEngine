using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Galaxaint
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GalaxaintGame game = new GalaxaintGame(800, 600, 30);
            game.Start();
            Application.Run();
        }
    }
}
