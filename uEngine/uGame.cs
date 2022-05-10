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

        protected uScene CurrentScene { set; get; }

        protected int DeltaTime { private set; get; }

        
        protected uGame(int windowWidth, int windowHeight, int targetFPS)
        {
            Window = new uWindow(windowWidth, windowHeight);
            TargetFPS = targetFPS;
        }

        private void GameLoop()
        {
            int targetMilliseconds = 1000 / TargetFPS;

            bool continueFlag = true;
            while (continueFlag)
            {
                if(CurrentScene == null)
                {
                    continueFlag = false;
                    continue;
                }


                Stopwatch sw = new Stopwatch();
                sw.Start();

                ProcessInput();
                GameUpdate(DeltaTime);
                Render(Window.GetGraphics());
                
                //realiza el cambio del buffer
                Window.Render();

                //actualizo CurrentScene
                if (CurrentScene != null && !CurrentScene.IsAlive())
                {
                    CurrentScene = CurrentScene.Next();
                }

                sw.Stop();

                int elapsedMilliseconds = (int)sw.ElapsedMilliseconds;
                DeltaTime = elapsedMilliseconds;

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
        public abstract void GameUpdate(int DeltaTime);
        public virtual void Render(Graphics g)
        {
            CurrentScene.Render(g);
        }

    }
}
