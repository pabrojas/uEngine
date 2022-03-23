using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace uEngine
{
    public abstract class uGame
    {

        private int TargetFPS;
        protected uWindow Window;

        protected Point MouseLocation { get { return Window.MouseLocation; } }


        
        protected uGame(int windowWidth, int windowHeight, int targetFPS)
        {
            Window = new uWindow(windowWidth, windowHeight);
            TargetFPS = targetFPS;
        }

        private void GameLoop()
        {
            int targetMilliseconds = 1000 / TargetFPS;

            while (true)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                ProcessInput();
                GameUpdate();
                Render(Window.GetGraphics());
                
                //realiza el cambio del buffer
                Window.Render();


                sw.Stop();

                int elapsedMilliseconds = (int)sw.ElapsedMilliseconds;

                int pause = targetMilliseconds - elapsedMilliseconds;
                if (pause < 1)
                {
                    pause = 1;
                }
                
                Thread.Sleep(pause);

            }
        }

        public void Start()
        {
            Window.Show();
            Thread thread = new Thread(GameLoop);
            thread.Start();
        }



        public abstract void ProcessInput();
        public abstract void GameUpdate();
        public abstract void Render(Graphics g);

    }
}
