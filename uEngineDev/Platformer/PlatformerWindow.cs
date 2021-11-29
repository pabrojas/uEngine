using System;
using System.Windows;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;
using uEngine.sprites;

namespace Platformer
{
    class PlatformerWindow : uGame
    {
        private uSprite idle;
        private uSprite walk;
        private uSprite run;

        private List<uGameObject> ground;

        private uGameObject player;
        private int gravedadMundo;
        private int velocidadEjeYPlayer;


        private bool SaltoPresionado;





        public PlatformerWindow(int width, int height, uViewport viewport,  int targetFPS) : base(width, height, viewport, targetFPS)
        {
            
            InitializeSprites();

            gravedadMundo = 1;
            velocidadEjeYPlayer = 0;

            SaltoPresionado = false;

            uGameObject ugo;

            Image background = uResourcesManager.GetImage("background");
            uSingleSprite bg = new uSingleSprite(background, 1024, 768);

            for (int i = -3000; i < 3000; i += 1024)
            {
                ugo = new uGameObject(i, 0, 1024, 768, bg);
                Add(ugo);
            }

            player = new uGameObject(0, 68, 100, 100, idle);
            Add(player);

            int size = 50;
            ground = new List<uGameObject>();
            
            uSingleSprite sprite = new uSingleSprite(uResourcesManager.GetImage("ground"), 100, 100);
            for (int i = 0; i < 1024; i += size)
            {
                ugo = new uGameObject(i, 668, size, size, sprite);
                Add(ugo);
                ground.Add(ugo);
            }
            ugo = new uGameObject(400, 668 - size, size, size, sprite);
            Add(ugo);
            ground.Add(ugo);


        }

        private void InitializeSprites()
        {
            uAnimationByFramesSprite idle = new uAnimationByFramesSprite(100, 100, 50);
            for (int i = 1; i <= 16; i++)
            {
                idle.AddFrame(uResourcesManager.GetImage("idle" + i));
            }
            this.idle = idle;

            uAnimationByFramesSprite walk = new uAnimationByFramesSprite(100, 100, 50);
            for (int i = 1; i <= 20; i++)
            {
                walk.AddFrame(uResourcesManager.GetImage("walk" + i));
            }
            this.walk = walk;

            uAnimationByFramesSprite run = new uAnimationByFramesSprite(100, 100, 50);
            for (int i = 1; i <= 20; i++)
            {
                run.AddFrame(uResourcesManager.GetImage("run" + i));
            }
            this.run = run;
        }

        public override void GameUpdate()
        {
            player.Update(DeltaTime);

            velocidadEjeYPlayer += gravedadMundo;

            if (!hayColision())
            {
                player.Y += velocidadEjeYPlayer;

                if( hayColision() )
                {
                    //player.Y -= velocidadEjeYPlayer;
                    do
                    {
                        player.Y -= 1;
                    }
                    while (hayColision());

                    velocidadEjeYPlayer = 0;
                }

            }





        }

        public override void ProcessInput()
        {
            if (uInputManager.IsKeyPressed("Right"))
            {
                Viewport.X += 10;
                player.X += 10;
            }
            else if (uInputManager.IsKeyPressed("Left"))
            {
                Viewport.X -= 10;
                player.X -= 10;
            }


            double scale = 0.3;
            if (uInputManager.IsKeyPressed("Up"))
            {
                Viewport.Width -= 16 * scale;
                Viewport.Height -= 9 * scale;
            }
            else if (uInputManager.IsKeyPressed("Down"))
            {
                Viewport.Width += 16 * scale;
                Viewport.Height += 9 * scale;
            }




            /*
            int step = 2;
            uSprite sprite = null;
            int horizontal = 0;
            if ( uInputManager.IsKeyPressed("Right") )
            {
                
                player.Facing = Direction.Right;
                if (uInputManager.IsKeyPressed("ShiftKey"))
                {
                    sprite = run;
                    horizontal = step * 2;
                }
                else
                {
                    sprite = walk;
                    horizontal = step;
                }
            }
            else if (uInputManager.IsKeyPressed("Left"))
            {
                player.Facing = Direction.Left;
                if (uInputManager.IsKeyPressed("ShiftKey"))
                {
                    sprite = run;
                    horizontal = -step * 2;
                    
                }
                else
                {
                    sprite = walk;
                    horizontal = -step;
                    
                }
            }
            else
            {
                player.Sprite = idle;
            }

            if(sprite != null && horizontal != 0)
            {
                if (!hayColision())
                {
                    player.X += horizontal;
                    player.Sprite = sprite;

                    Viewport.X -= horizontal;

                    if( hayColision() )
                    {
                        //player.X -= horizontal;
                        Viewport.X += horizontal;
                    }
                    

                }
            }


            if( uInputManager.IsKeyPressed("Space") )
            {
                if( SaltoPresionado == false )
                {
                    SaltoPresionado = true;
                    velocidadEjeYPlayer = -20;
                }
            }
            else
            {
                SaltoPresionado = false;
            }



            */



        }

        public override void Render(Graphics g)
        {
            //Image background = uResourcesManager.GetImage("background");
            //g.DrawImage(background, 0, 0, 1024, 768);

            base.Render(g);
        }

        private bool hayColision()
        {
            foreach (uGameObject element in ground)
            {
                Rect r1 = new Rect(player.X, player.Y, player.Width, player.Height);
                Rect r2 = new Rect(element.X, element.Y, element.Width, element.Height);
                if (r1.IntersectsWith(r2))
                {
                    return true;
                }


            }
            return false;
        }
    }
}
