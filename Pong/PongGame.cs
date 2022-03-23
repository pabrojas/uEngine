using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uEngine;

namespace Pong
{
    public class PongGame : uGame
    {
        private int MouseY;
        private Point ball;
        private int speed;
        private int dx;
        private int dy;
        int playerPoints;
        int cpuPoints;
        private Timer timer;
        private Random random;

        public PongGame(int windowWidth, int windowHeight, int targetFPS) 
            : base(windowWidth, windowHeight, targetFPS)
        {
            MouseY = Window.ClientSize.Height / 2;
            ball = new Point(Window.ClientSize.Width / 2, Window.ClientSize.Height / 2);
            speed = 5;
            dx = 1;
            dy = 1;

            playerPoints = 0;
            cpuPoints = 0;
            random = new Random();
        }

        public override void GameUpdate()
        {
            bool reiniciar = false;
            if (dx == 1)
            {
                if (ball.X + 20 >= Window.ClientSize.Width - 36)
                {
                    reiniciar = true;
                    playerPoints++;
                }
            }
            else
            {
                if (ball.X < 24)
                {
                    reiniciar = true;
                    cpuPoints++;
                }
            }

            if (ball.Y - 10 < 84)
            {
                dy = 1;
            }
            else if (ball.Y + 10 > Window.ClientSize.Height - 24)
            {
                dy = -1;
            }


            ball.X += dx * speed;
            ball.Y += dy * speed;

            if (reiniciar)
            {
                ball = new Point(Window.ClientSize.Width / 2, Window.ClientSize.Height / 2);
                speed = 5;
                dx = random.Next(2) == 0 ? 1 : -1;
                dy = random.Next(2) == 0 ? 1 : -1;
                reiniciar = false;

            }
        }
    
        public override void ProcessInput()
        {
            MouseY = MouseLocation.Y;
        }

        public override void Render(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);

            g.FillRectangle(brush, 40, MouseY - 50, 20, 100);
            g.FillEllipse(brush, ball.X - 10, ball.Y - 10, 20, 20);


            //         (24, 84)       (ClientSize.Width - 36,84)
            //              +---------------------+
            //              |                     |
            //              |                     |
            //              +---------------------+
            // (24, ClientSize.Height - 24)   (ClientSize.Width - 36, ClientSize.Height - 24
            g.FillRectangle(brush, 20, 80, Window.ClientSize.Width - 40, 4);
            g.FillRectangle(brush, 20, Window.ClientSize.Height - 24, Window.ClientSize.Width - 40, 4);
            g.FillRectangle(brush, 20, 80, 4, Window.ClientSize.Height - 104);
            g.FillRectangle(brush, Window.ClientSize.Width - 24, 80, 4, Window.ClientSize.Height - 104);


            for (int i = 80; i < Window.ClientSize.Height; i += 100)
            {
                g.FillRectangle(brush, Window.ClientSize.Width / 2 - 2, i, 4, 60);
            }

            Font font = new Font("Courier New", 32, FontStyle.Bold);
            g.DrawString((playerPoints < 10 ? "0" : "") + playerPoints, font, brush, 10, 10);

        }
    }
}
