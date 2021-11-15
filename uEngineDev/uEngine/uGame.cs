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

        private List<uGameObject> gameObjects;

        public uGame(int width, int height, int targetFPS)
        {
            Window = new uWindow(width, height);
            TargetFPS = targetFPS;

            gameObjects = new List<uGameObject>();
        }

        public void Add(uGameObject ugo)
        {
            gameObjects.Add(ugo);
        }

        public void Remove(uGameObject ugo)
        {
            gameObjects.Remove(ugo);
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

        
        public virtual void Render(Graphics g)
        {
            foreach (uGameObject ugo in gameObjects)
            {
                Image image = ugo.Sprite.GetCurrentFrame();
                Image toPaint = (Image)image.Clone();

                if (ugo.Facing == Direction.Left)
                {
                    toPaint.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                g.DrawImage(toPaint, ugo.X, ugo.Y, ugo.Width, ugo.Height);
            }
        }

        public abstract void ProcessInput();
        public abstract void GameUpdate();
    }

}
