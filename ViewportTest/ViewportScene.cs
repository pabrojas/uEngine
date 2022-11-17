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
    enum Direction { Quiet, Right, Left }
    public class ViewportScene : uScene
    {
        private List<uGameObject> ground;
        private List<uGameObject> coins;

        private uGameObject player;
        private Direction playerDirection;

        private float playerYSpeed;
        private float gravity;

        private uSprite spritePlayerIdle;
        private uSprite spritePlayerWalk;

        private bool toJump;

        public ViewportScene()
        {
            playerYSpeed = 0;
            gravity = 1;
            toJump = false;

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
            float pw = 416 / 4;
            float ph = 454 / 4;
            Image iPlayer = uResourcesManager.GetImage("player");
            player = new uGameObject(
                new uBounds<float>(340, 460 - ph, pw, ph), 
                new uBounds<float>(30, 10, pw-60, ph-10),
                spritePlayerWalk) ;
            playerDirection = Direction.Quiet;


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

            uSprite block = new uSprite(1);
            block.Add(top);
            uGameObject ugo = new uGameObject(new uBounds<float>(100, 250, 70, 70), block);
            ground.Add(ugo);

            coins = new List<uGameObject>();
            Image coinImage = uResourcesManager.GetImage("coin");
            for (int i = 0; i < 1000; i += 100)
            {
                uSprite coinSprite = new uSprite(1);
                coinSprite.Add(coinImage);
                uGameObject coinGO = new uGameObject(new uBounds<float>(i, 350, 64, 64), coinSprite);
                coins.Add(coinGO);
            }


        }

        public void GameUpdate(int DeltaTime)
        {
            player.Sprite.Update(DeltaTime);

            //salto
            if( toJump == true )
            {
                playerYSpeed = -14;
                toJump = false;
            }

            //Movimiento vertical
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
                    if( playerYSpeed > 0 )
                    {
                        player.Bounds.Y = go.Bounds.Y - player.BoundingBox().Height + (player.Bounds.Y - player.BoundingBox().Y) - 1 ;
                    }
                    else if(playerYSpeed < 0)
                    {
                        player.Bounds.Y = go.Bounds.Y + go.Bounds.Height + (player.Bounds.Y - player.BoundingBox().Y) + 1;
                    }

                    playerYSpeed = 0;
                }
            }

            //movimiento horizontal
            if( playerDirection == Direction.Right )
            {
                player.Bounds.X += 5;
                uGame.Viewport.X += 5;
                player.Sprite = spritePlayerWalk;
                player.Facing = Facing.Right;

                rPlayer = new Rect(player.BoundingBox().X, player.BoundingBox().Y, player.BoundingBox().Width, player.BoundingBox().Height);
                foreach (uGameObject ugo in ground)
                {
                    Rect rGO = new Rect(ugo.BoundingBox().X, ugo.BoundingBox().Y, ugo.BoundingBox().Width, ugo.BoundingBox().Height);
                    if ( rPlayer.IntersectsWith(rGO) )
                    {
                        player.Bounds.X = ugo.Bounds.X - player.Bounds.Width + (player.BoundingBox().X - player.Bounds.X) - 1;
                        uGame.Viewport.X -= 5;
                    }
                }
            }
            else if( playerDirection == Direction.Left )
            {
                player.Bounds.X -= 5;
                uGame.Viewport.X -= 5;
                player.Sprite = spritePlayerWalk;
                player.Facing = Facing.Left;

                rPlayer = new Rect(player.BoundingBox().X, player.BoundingBox().Y, player.BoundingBox().Width, player.BoundingBox().Height);
                foreach (uGameObject ugo in ground)
                {
                    Rect rGO = new Rect(ugo.BoundingBox().X, ugo.BoundingBox().Y, ugo.BoundingBox().Width, ugo.BoundingBox().Height);
                    if (rPlayer.IntersectsWith(rGO))
                    {
                        player.Bounds.X = ugo.Bounds.X + ugo.Bounds.Width - (player.BoundingBox().X - player.Bounds.X) + 1;
                        uGame.Viewport.X += 5;
                    }
                }
            }
            else
            {
                player.Sprite = spritePlayerIdle;
            }

            //check coins collision
            List<uGameObject> toRemoveCoins = new List<uGameObject>();
            rPlayer = new Rect(player.BoundingBox().X, player.BoundingBox().Y, player.BoundingBox().Width, player.BoundingBox().Height);
            foreach (uGameObject ugo in coins)
            {
                Rect rGO = new Rect(ugo.BoundingBox().X, ugo.BoundingBox().Y, ugo.BoundingBox().Width, ugo.BoundingBox().Height);
                if (rPlayer.IntersectsWith(rGO))
                {
                    toRemoveCoins.Add(ugo);
                }
            }

            foreach (uGameObject coin in toRemoveCoins)
            {
                coins.Remove(coin);
            }

        }

        public void ProcessInputs()
        {
            if (uInputManager.IsKeyPressed(Keys.Right))
            {
                playerDirection = Direction.Right;
            }
            else if (uInputManager.IsKeyPressed(Keys.Left))
            {
                playerDirection = Direction.Left;
            }
            else
            {
                playerDirection = Direction.Quiet;
            }

            if (uInputManager.IsKeyPressed(Keys.Space))
            {
                if (checkIfPlayerCanJump() == true)
                {
                    toJump = true;
                }
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

            foreach (uGameObject ugo in ground)
            {
                uBounds<int> ventana = uConverter.Parse(ugo.Bounds);
                g.DrawImage(ugo.GetImage(), ventana.X, ventana.Y, ventana.Width, ventana.Height);
            }

            foreach (uGameObject ugo in coins)
            {
                uBounds<int> ventana = uConverter.Parse(ugo.Bounds);
                g.DrawImage(ugo.GetImage(), ventana.X, ventana.Y, ventana.Width, ventana.Height);
            }


            uBounds<int> playerBounds = uConverter.Parse(player.Bounds);
            g.DrawImage(player.GetImage(), playerBounds.X, playerBounds.Y, playerBounds.Width, playerBounds.Height);
            /*
            uBounds<int> playerBBox = uConverter.Parse(player.BoundingBox());
            g.DrawRectangle(new Pen(Color.Red), playerBounds.X, playerBounds.Y, playerBounds.Width, playerBounds.Height);
            g.DrawRectangle(new Pen(Color.Black), playerBBox.X, playerBBox.Y, playerBBox.Width, playerBBox.Height);
            */





        }


        private bool checkIfPlayerCanJump()
        {
            Rect rPlayer = new Rect(player.BoundingBox().X, 
                player.BoundingBox().Y + 1,
                player.BoundingBox().Width,
                player.BoundingBox().Height);

            foreach (uGameObject go in ground)
            {
                Rect rGO = new Rect(go.BoundingBox().X, go.BoundingBox().Y, go.BoundingBox().Width, go.BoundingBox().Height);

                if (rPlayer.IntersectsWith(rGO))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
