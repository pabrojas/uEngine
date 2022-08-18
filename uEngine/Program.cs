using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class Program
    {
        static public void Main(string[] args)
        {
            uGame game = new uGame(1024, 768, 30);
            game.Start();

            Application.Run();
        }
    }
}
