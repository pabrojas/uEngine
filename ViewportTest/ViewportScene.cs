using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using uEngine;
using uEngine.Managers;

namespace ViewportTest
{
    public class ViewportScene : uScene
    {
        private List<uGameObject> ground;

        private uGameObject player;

        private float playerYSpeed;
        private float gravity;

        private uSprite spritePlayerIdle;
        private uSprite spritePlayerWalk;

        public ViewportScene()
        {
            playerYSpeed = 0;
            gravity = 1;

            spritePlayerIdle = new uSprite(15);
            for (int i = 1; i < 17; i++)
            {
                spritePlayerIdle.Add(uResourcesManager.GetImage("player" + i));
            }

            spritePlayerWalk = new uSprite(15);
            for (int i = 1; i < 21; i++)
            {
                spritePlayerWalk.Add(uResourcesManager.GetImage("walk" + i));
            }


            //120 x 201
            Image iPlayer = uResourcesManager.GetImage("player");
            player = new uGameObject(
                new uBounds<float>(340, 460 - 454/2, 416/2, 454/2), 
                /*new uBounds<float>(0, 0, 120, 150),*/
                spritePlayerWalk) ;


            ground = new List<uGameObject>();
            Image top = uResourcesManager.GetImage("top");
            Image bottom = uResourcesManager.GetImage("bottom");
            for (int i = -5000; i < 5000; i += 70)
            {
                uSprite spriteBottom = new uSprite(1);
                spriteBottom.Add(bottom);
                uGameObject go = new uGameObject(new uBounds<float>(i, 530, 70, 70), spriteBottom);
                ground.Add(go);

                uSprite spriteTop = new uSprite(1);
                spriteTop.Add(top);
                go = new uGameObject(new uBounds<float>(i, 460, 70, 70), spriteTop);
                ground.Add(go);
            }
        }

        public void GameUpdate(int DeltaTime)
        {
            player.Sprite.Update(DeltaTime);


            playerYSpeed += gravity;
            player.Bounds.Y += playerYSpeed;

            Rect rPlayer = new Rect(player.BoundingBox().X, 
                player.BoundingBox().Y, 
                player.BoundingBox().Width, 
                player.BoundingBox().Height);
            foreach (uGameObject go in ground)
            {
                Rect rGO = new Rect(go.BoundingBox().X, 
                    go.BoundingBox().Y, 
                    go.BoundingBox().Width, 
                    go.BoundingBox().Height);
                
                if( rPlayer.IntersectsWith(rGO) )
                {
                    player.Bounds.Y -= playerYSpeed;
                    playerYSpeed = 0;
                }
            }

        }

        public void ProcessInputs()
        {
            if( uInputManager.IsKeyPressed(Keys.Right) )
            {
                player.Bounds.X += 5;
                uGame.Viewport.X += 5;
                player.Sprite = spritePlayerWalk;
            }
            else if (uInputManager.IsKeyPressed(Keys.Left))
            {
                player.Bounds.X -= 5;
                uGame.Viewport.X -= 5;
                player.Sprite = spritePlayerWalk;
            }
            else
            {
                player.Sprite = spritePlayerIdle;
            }

            if (uInputManager.IsKeyPressed(Keys.Space))
            {
                playerYSpeed = -10;
            }
        }

        public void Render(Graphics g)
        {
            Image background = uResourcesManager.GetImage("background");

            for (int i = -5000; i < 5000; i += 600)
            {
                uBounds<float> mundo = new uBounds<float>(i, 0, 600, 600);
                uBounds<int> ventana = uConverter.Parse(mundo);
                g.DrawImage(background, ventana.X, ventana.Y, ventana.Width, ventana.Height);

            }

            foreach (uGameObject ugo  in ground)
            {
                uBounds<int> ventana = uConverter.Parse(ugo.Bounds);
                g.DrawImage(ugo.Sprite.Current(), ventana.X, ventana.Y, ventana.Width, ventana.Height);
            }

            uBounds<int> playerBounds = uConverter.Parse(player.Bounds);
            g.DrawImage(player.Sprite.Current(), playerBounds.X, playerBounds.Y, playerBounds.Width, playerBounds.Height);


        }
    }
}
