using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using uEngine.Managers;
using uEngine;

namespace Connect4.Scenes
{
    public class FinishScene : uScene
    {
        private int winner;

        public void setWinner(int winner)
        {
            this.winner = winner;
        }

        public void GameUpdate(int DeltaTime)
        {
        }

        public void ProcessInputs()
        {
        }

        public void Render(Graphics g)
        {
            
        }
    }
}
