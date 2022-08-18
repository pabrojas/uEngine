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
    public abstract class uGame
    {
        //Atributos de mi motor
        private int targetTime { get; set; }
        private uWindow MainWindow;

        public static int WindowWidth { get; private set; }
        public static int WindowHeight { get; private set; }

        public uGame(int windowWidth, int windowHeight, int FPS)
        {
            targetTime = 1000 / FPS;
            MainWindow = new uWindow(windowWidth, windowHeight);

            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
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
            while (continuar)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                ProcessInputs();
                GameUpdate();
                Render(MainWindow.GetGraphics());
                //realiza el cambio del buffer
                MainWindow.Render();

                sw.Stop();

                int deltaTime = (int)sw.ElapsedMilliseconds;
                int sleepTime = targetTime - deltaTime;

                if (sleepTime < 0)
                {
                    sleepTime = 1;
                }
                Thread.Sleep(sleepTime);

                if (MainWindow.IsDisposed)
                {
                    continuar = false;
                }

            }
            Environment.Exit(0);
        }


        public abstract void ProcessInputs();
        public abstract void GameUpdate();
        public abstract void Render(Graphics g);

    }
}
