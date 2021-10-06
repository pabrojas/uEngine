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
        private uWindow Window;
        private int TargetFPS { set; get; }

        public int DeltaTime { private set; get; }


        public uGame(int width, int height, int targetFPS)
        {
            Window = new uWindow(width, height);
            TargetFPS = targetFPS;
        }

        public void Start()
        {
            Window.Show();
            Thread thread = new Thread(GameLoop);
            thread.Start();
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
                Window.Render();
                sw.Stop();

                int elapsedMilliseconds = (int)sw.ElapsedMilliseconds;
                DeltaTime = elapsedMilliseconds;
            
                int pause = targetMilliseconds - elapsedMilliseconds;
                if (pause < 1)
                {
                    pause = 1;
                }
                DeltaTime += pause;

                Thread.Sleep(pause);

            }
        }

        public abstract void ProcessInput();
        public abstract void GameUpdate();
        public abstract void Render(Graphics g);
    }

}
