using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace uEngine
{
    //esta clase no sigue la regla del 1-1
    public class uGame
    {
        //Atributos del juego actual que estoy creando
        private int padY { get; set; }
        private int ballX { get; set; }
        private int ballY { get; set; }

        private int dx { get; set; }
        private int dy { get; set; }



        //Atributos de mi motor
        private int targetTime { get; set; }
        private uWindow MainWindow;

        public uGame(int windowWidth, int windowHeight, int FPS)
        {
            targetTime = 1000 / FPS;
            MainWindow = new uWindow(windowWidth, windowHeight);

            padY = windowHeight / 2;
            ballX = windowWidth / 2;
            ballY = windowHeight / 2;
            dx = 1;
            dy = 1;
        }

        public void Start()
        {
            MainWindow.Show();
            Thread thread = new Thread(GameLoop);
            thread.Start();
        }


        private void GameLoop()
        {
            
            bool continuar = true;
            while(continuar)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ProcessInputs();
                GameUpdate();
                Render();
                sw.Stop();

                int deltaTime = (int)sw.ElapsedMilliseconds;
                int sleepTime = targetTime - deltaTime;

                if( sleepTime < 0 )
                {
                    sleepTime = 1;
                }
                Thread.Sleep(sleepTime);

                if( MainWindow.IsDisposed )
                {
                    continuar = false;
                }

            }
            Environment.Exit(0);


        }


        public void ProcessInputs()
        {
            int step = 10;
            if( MainWindow.IsKeyPressed(Keys.Up))
            {
                padY -= step;
            }
            else if( MainWindow.IsKeyPressed(Keys.Down))
            {
                padY += step;
            }
        }

        public void GameUpdate()
        {
            int step = 10;
            ballX += dx * step;
            ballY += dy * step;

            if (ballY >= MainWindow.ClientSize.Height)
            {
                dy = -1;
            }
            else if (ballY <= 0)
            {
                dy = 1;
            }

            if (ballX >= MainWindow.ClientSize.Width)
            {
                dx = -1;
            }
            else if (ballX <= 0)
            {
                dx = 1;
            }


        }

        public void Render()
        {
            Graphics g = MainWindow.CreateGraphics();
            //borro el fondo y lo pinto negro
            g.FillRectangle(new SolidBrush(Color.Black), 
                0, 0, 
                MainWindow.ClientSize.Width, MainWindow.ClientSize.Height);

            //pinto el PAD
            g.FillRectangle(new SolidBrush(Color.White),
                10, padY, 20, 100);

            //pinto la pelota
            g.FillEllipse(new SolidBrush(Color.White),
                ballX, ballY, 20, 20);

        }


    }
}
