using System;
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

        private uGameObject player;

        public PlatformerWindow(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {

            InitializeSprites();

            player = new uGameObject(0, 568, 100, 100, idle);
            Add(player);

            uSingleSprite sprite = new uSingleSprite(uResourcesManager.GetImage("ground"), 100, 100);
            for (int i = 0; i < 1024; i += 100)
            {
                Add(new uGameObject(i, 668, 100, 100, sprite));
            }
            Add(new uGameObject(400, 568, 100, 100, sprite));


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
        }

        public override void ProcessInput()
        {
            int step = 2;
            if( uInputManager.IsKeyPressed("Right") )
            {
                player.Facing = Direction.Right;
                if (uInputManager.IsKeyPressed("ShiftKey"))
                {
                    player.X += step*2;
                    player.Sprite = run;
                }
                else
                {
                    player.X += step;
                    player.Sprite = walk;
                }
            }
            else if (uInputManager.IsKeyPressed("Left"))
            {
                player.Facing = Direction.Left;
                if (uInputManager.IsKeyPressed("ShiftKey"))
                {
                    player.X -= step * 2;
                    player.Sprite = run;
                }
                else
                {
                    player.X -= step;
                    player.Sprite = walk;
                }
            }
            else
            {
                player.Sprite= idle;
            }


        }

        public override void Render(Graphics g)
        {
            Image background = uResourcesManager.GetImage("background");
            g.DrawImage(background, 0, 0, 1024, 768);

            base.Render(g);
        }

        /*
        public override void Render(Graphics g)
        {
            Image image = player.Sprite.GetCurrentFrame();
            Image toPaint = (Image)image.Clone();

            if (player.Facing == Direction.Left)
            {
                toPaint.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
             
            g.DrawImage(toPaint, player.X, player.Y, player.Width, player.Height);
            


        }*/
    }
}
