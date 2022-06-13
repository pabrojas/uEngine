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
        public uViewport Viewport { private set; get; }

        public int WindowWidth { get { return Window.ClientSize.Width; } }
        public int WindowHeight { get { return Window.ClientSize.Height; } }

        protected uScene CurrentScene { set; get; }

        protected int DeltaTime { private set; get; }

        protected List<uGameObject> GameObjects;

        protected uGame(uViewport viewport, int windowWidth, int windowHeight, int targetFPS)
        {
            this.Viewport = viewport;
            Window = new uWindow(windowWidth, windowHeight);
            TargetFPS = targetFPS;

            GameObjects = new List<uGameObject>();
        }

        public void SetIcon(Image image)
        {
            Bitmap b = (Bitmap)image;
            IntPtr pIcon = b.GetHicon();
            Icon icon = Icon.FromHandle(pIcon);
            this.Window.Icon = icon;
            icon.Dispose();
        }

        public void ClearGameObjects()
        {
            GameObjects.Clear();
        }

        public void Add(uGameObject ugo)
        {
            GameObjects.Add(ugo);
        }

        public int CountGameObjects()
        {
            return GameObjects.Count;
        }

        public uGameObject GetGameObject(int i)
        {
            return GameObjects[i];
        }

        public void RemoveGameObject(int i)
        {
            GameObjects.RemoveAt(i);
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
        public virtual void GameUpdate(int DeltaTime)
        {
            foreach(uGameObject ugo in GameObjects)
            {
                if (ugo.Sprite != null)
                {
                    ugo.Sprite.Update(DeltaTime);
                }
            }
        }

        public virtual void Render(Graphics g)
        {
            CurrentScene.Render(g);
        }

    }
}
