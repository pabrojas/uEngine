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
        public int WindowWidth { private set; get; }
        public int WindowHeight { private set; get; }

        private uWindow Window;
        private int TargetFPS { set; get; }

        protected uViewport Viewport;

        public int DeltaTime { private set; get; }

        private List<uGameObject> gameObjects;

        public uGame(int width, int height, uViewport viewport, int targetFPS)
        {
            WindowWidth = width;
            WindowHeight = height;
            Window = new uWindow(width, height);
            Viewport = viewport;
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
                if (Viewport.Contains(ugo))
                {

                    Image image = ugo.Sprite.GetCurrentFrame();
                    Image toPaint = (Image)image.Clone();

                    if (ugo.Facing == Direction.Left)
                    {
                        toPaint.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                    else if (ugo.Facing == Direction.Up)
                    {
                        toPaint.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    else if (ugo.Facing == Direction.Down)
                    {
                        toPaint.RotateFlip(RotateFlipType.Rotate270FlipY);
                    }

                    double xRatio = Viewport.Width / WindowWidth;
                    double yRatio = Viewport.Height / WindowHeight;
                    uWindowObject uwo = uWindowObject.Parse(ugo, Viewport, xRatio, yRatio);
                    g.DrawImage(toPaint, uwo.X, uwo.Y, uwo.Width, uwo.Height);
                }
            }
        }

        public abstract void ProcessInput();
        public abstract void GameUpdate();
    }

}
