using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Connect4.View;
using uEngine.Managers;

namespace Connect4
{
    public class Program
    {
        static void Main(string[] args)
        {
            uResourcesManager.LoadImage("Board.png", "board");
            uResourcesManager.LoadImage("TokenRed.png", "red");
            uResourcesManager.LoadImage("TokenYellow.png", "yellow");

            uAudioPool.Load("bong_001.mp3", "bong");

            uResourcesManager.LoadFont("Kenney Future.ttf", "font");

            Connect4Game game = new Connect4Game(1300, 900, 60);
            game.Start();

            Application.Run();
        }
    }
}
