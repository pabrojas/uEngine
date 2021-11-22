using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;
using uEngine.sprites;

namespace u2lab2
{
    class GameWindow : uGame
    {
        private uGameObject player;
        private List<uGameObject> elements;

        public GameWindow(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            uSingleSprite playerSprite = new uSingleSprite(uResourcesManager.GetImage("player"), 42, 62);
            player = new uGameObject(300, 300, 52, 62, playerSprite);
            Add(player);

            
            elements = new List<uGameObject>();

            uSingleSprite elementSprite = new uSingleSprite(uResourcesManager.GetImage("soccer"), 42, 62);
            uGameObject element = new uGameObject(200, 100, 36, 36, elementSprite);
            Add(element);
            elements.Add(element);

            element = new uGameObject(500, 500, 36, 36, elementSprite);
            Add(element);
            elements.Add(element);

            element = new uGameObject(600, 350, 36, 36, elementSprite);
            Add(element);
            elements.Add(element);


        }

        public override void GameUpdate()
        {
            
        }

        public override void ProcessInput()
        {
            int step = 10;
            if (uInputManager.IsKeyPressed("Left"))
            {
                player.Facing = Direction.Left;

                if (!hayColision())
                {
                    player.X -= step;
                    if( hayColision() )
                    {
                        player.X += step;
                    }
                }
            }
            else if (uInputManager.IsKeyPressed("Right"))
            {
                player.Facing = Direction.Right;
                if (!hayColision())
                {
                    player.X += step;
                    if (hayColision())
                    {
                        player.X -= step;
                    }
                }
            }
            else if (uInputManager.IsKeyPressed("Up"))
            {
                player.Facing = Direction.Up;
                if (!hayColision())
                {
                    player.Y -= step;
                    if (hayColision())
                    {
                        player.Y += step;
                    }
                }
            }
            else if (uInputManager.IsKeyPressed("Down"))
            {
                player.Facing = Direction.Down;
                if (!hayColision())
                {
                    player.Y += step;
                    if (hayColision())
                    {
                        player.Y -= step;
                    }
                }
            }


        }

        public override void Render(Graphics g)
        {
            DrawField(g);

            base.Render(g);
        }

        private void DrawField(Graphics g)
        {
            bool light = true;
            for (int i = 0; i < 1024; i += 103)
            {
                for (int j = 0; j < 768; j += 77)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(46, 204, 113));
                    if (light)
                    {
                        brush = new SolidBrush(Color.FromArgb(49, 217, 120));
                    }

                    g.FillRectangle(brush, i, j, 103, 768);

                    light = !light;
                }
                light = !light;

            }
        }

        private bool hayColision()
        {
            foreach (uGameObject element in elements)
            {
                //(player, element)
                Rectangle r1 = new Rectangle(player.X, player.Y, player.Width, player.Height);
                Rectangle r2 = new Rectangle(element.X, element.Y, element.Width, element.Height);
                if( r1.IntersectsWith(r2) )
                {
                    return true;
                }


            }
            return false;
        }
        
    }
}
