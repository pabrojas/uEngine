using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using Connect4.View;

namespace Connect4
{
    public class Program
    {
        static void Main(string[] args)
        {
            uImageManager.Load("Board.png", "board");
            uImageManager.Load("TokenRed.png", "red");
            uImageManager.Load("TokenYellow.png", "yellow");

            Connect4Game game = new Connect4Game(1300, 900, 60);
            game.Start();

            Application.Run();
        }
    }
}
