using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Model
{
    public class PongLogic
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

        public PongLogic(int courtWidth, int courtHeight)
        {
            CourtWidth = courtWidth;
            CourtHeight = courtHeight;

            Generator = new Random();
            InitiaizeDeltas();

            WinningPoints = 5;

            PadSpeed = 5;
            PlayerPad = new Rectangle(20, CourtHeight / 2 - 50, 20, 100);
            ComputerPad = new Rectangle(CourtWidth - 40, CourtHeight / 2 - 50, 20, 100);

            Ball = new Rectangle(CourtWidth / 2, CourtHeight / 2, 20, 20);


            PlayerPoints = 0;
            ComputerPoints = 0;

        }

        private void InitiaizeDeltas()
        {
            dx = Generator.Next(0, 2);
            if (dx == 0)
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
            PlayerPad = new Rectangle(
                    PlayerPad.X,
                    PlayerPad.Y - PadSpeed,
                    PlayerPad.Width,
                    PlayerPad.Height);

            if (PlayerPad.Y < 0 + lineWidth)
            {
                PlayerPad = new Rectangle(
                    PlayerPad.X,
                    lineWidth,
                    PlayerPad.Width,
                    PlayerPad.Height);
            }
        }
        public void MovePlayerPadDown(int lineWidth)
        {
            PlayerPad = new Rectangle(
                    PlayerPad.X,
                    PlayerPad.Y + PadSpeed,
                    PlayerPad.Width,
                    PlayerPad.Height);
            if (PlayerPad.Y + PlayerPad.Height > CourtHeight)
            {
                PlayerPad = new Rectangle(
                    PlayerPad.X,
                    CourtHeight - PlayerPad.Height,
                    PlayerPad.Width,
                    PlayerPad.Height);
            }

        }

        public void Update()
        {
            int ballSpeed = 10;
            Ball = new Rectangle(
                Ball.X + dx * ballSpeed, 
                Ball.Y + dy * ballSpeed, 
                Ball.Width, 
                Ball.Height);


            if( ComputerPad.Y + ComputerPad.Height/2 > Ball.Y + Ball.Height/2 )
            {
                ComputerPad = new Rectangle(
                    ComputerPad.X,
                    ComputerPad.Y - PadSpeed,
                    ComputerPad.Width,
                    ComputerPad.Height);
            }
            else if(ComputerPad.Y + ComputerPad.Height / 2 < Ball.Y + Ball.Height / 2)
            {
                ComputerPad = new Rectangle(
                    ComputerPad.X,
                    ComputerPad.Y + PadSpeed,
                    ComputerPad.Width,
                    ComputerPad.Height);
            }

            

            if( ComputerPad.IntersectsWith(Ball) )
            {
                dx = -1;
            }

            if (PlayerPad.IntersectsWith(Ball))
            {
                dx = 1;
            }


            if (Ball.Y + Ball.Height > CourtHeight)
            {
                dy = -1;
            }
            else if (Ball.Y < 0)
            {
                dy = 1;
            }

            if (Ball.X < 0)
            {
                dx = 1;
                ComputerPoints++;
                Ball = new Rectangle(CourtWidth / 2, CourtHeight / 2, 20, 20);
                InitiaizeDeltas();
            }
            else if (Ball.X + Ball.Width > CourtWidth)
            {
                dx = -1;
                PlayerPoints++;
                Ball = new Rectangle(CourtWidth / 2, CourtHeight / 2, 20, 20);
                InitiaizeDeltas();
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