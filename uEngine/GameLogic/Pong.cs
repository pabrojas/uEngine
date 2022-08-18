using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.GameLogic
{
    public class Pong
    {
        private Random Generator;
        public Rectangle PlayerPad { get; set; }
        public Rectangle ComputerPad { get; set; }
        public Rectangle Ball { get; set; }

        public int PlayerPoints { get; set; }
        public int ComputerPoints { get; set; }

        private int dx;
        private int dy;

        private int CourtWidth;
        private int CourtHeight;

        private int PadSpeed;
        private int WinningPoints;

        public Pong(int courtWidth, int courtHeight)
        {
            CourtWidth = courtWidth;
            CourtHeight = courtHeight;

            Generator = new Random();
            InitiaizeDeltas();

            WinningPoints = 1;

            PadSpeed = 5;
            PlayerPad = new Rectangle(20, CourtHeight / 2 - 50, 20, 100);
            ComputerPad = new Rectangle(CourtWidth - 40, CourtHeight / 2 - 50, 20, 100);
            
            Ball = new Rectangle(CourtWidth / 2, CourtHeight / 2, 20, 20);
            

            PlayerPoints = 0;
            ComputerPoints = 0;

        }

        public void InitiaizeDeltas()
        {
            dx = Generator.Next(0, 2);
            if(dx == 0)
            {
                dx = -1;
            }

            dy = Generator.Next(0, 2);
            if (dy == 0)
            {
                dy = -1;
            }
        }

        public void MovePlayerPadUp(int lineWidth)
        {
            PlayerPad.Y -= PadSpeed;
            if(PlayerPad.Y < 0 + lineWidth)
            {
                PlayerPad.Y = lineWidth;
            }
        }
        public void MovePlayerPadDown(int lineWidth)
        {
            PlayerPad.Y += PadSpeed;
            if(PlayerPad.Y + PlayerPad.Height > CourtHeight)
            {
                PlayerPad.Y = CourtHeight - PlayerPad.Height;
            }

        }

        public void Update()
        {
            int ballSpeed = 10;
            Ball.X += dx * ballSpeed;
            Ball.Y += dy * ballSpeed;

            if( Ball.Y + Ball.Height > CourtHeight )
            {
                dy = -1;
            }
            else if( Ball.Y < 0 )
            {
                dy = 1;
            }

            if( Ball.X < 0 )
            {
                dx = 1;
                ComputerPoints++;
            }
            else if( Ball.X + Ball.Width > CourtWidth )
            {
                dx = -1;
                PlayerPoints++;
            }


        }

        public bool IsEnded()
        {
            return PlayerPoints >= WinningPoints || ComputerPoints >= WinningPoints;
        }

        public bool PlayerWon()
        {
            return PlayerPoints >= WinningPoints;
        }

        public bool ComputerWon()
        {
            return ComputerPoints >= WinningPoints;
        }
    }
}