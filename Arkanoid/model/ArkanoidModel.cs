using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;


namespace Arkanoid.model
{
    public class ArkanoidModel
    {
        public List<Rectangle> hWalls;
        public List<Rectangle> vWalls;
        public List<Rectangle> Blocks;
        public Rectangle Pad;
        public Rectangle Ball;

        public bool BallMoving;
        public int dx;
        public int dy;
        public int BallSpeed;

        public ArkanoidModel()
        {
            InitializeBlocks();
            CreateWalls();

            Pad = new Rectangle(350, 550, 100, 20, Color.Red, Color.Black);
            Ball = new Rectangle(390, 530, 20, 20, Color.Red, Color.Black);
            BallMoving = false;
            dx = 1;
            dy = -1;
            BallSpeed = 10;
        }

        private void CreateWalls()
        {
            hWalls = new List<Rectangle>();

            for (int i = 0; i < 8; i++)
            {
                hWalls.Add(new Rectangle(i * 100, 0, 100, 20, Color.DarkGray, Color.Black));
            }

            vWalls = new List<Rectangle>();
            for (int i = 0; i < 6; i++)
            {
                vWalls.Add(new Rectangle(0, 20 + i * 100, 20, 100, Color.DarkGray, Color.Black));
                vWalls.Add(new Rectangle(780, 20 + i * 100, 20, 100, Color.DarkGray, Color.Black));
            }


        }

        private void InitializeBlocks()
        {
            Blocks = new List<Rectangle>();

            List<Color> colors = new List<Color>();
            colors.Add(Color.Gray);
            colors.Add(Color.Red);
            colors.Add(Color.Yellow);
            colors.Add(Color.LightBlue);

            for (int j = 0; j < colors.Count; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    Blocks.Add(new Rectangle(100 + i * 100, 100 + 20 * j, 100, 20, colors[j], Color.Black));
                }
            }

        }

        private void reinit()
        {
            BallMoving = false;
            Ball.Y = 530;
            dx = 1;
            dy = -1;
        }

        public void Update()
        {
            if (Pad.X < 20)
            {
                Pad.X = 20;
            }
            if (Pad.X > 680)
            {
                Pad.X = 680;
            }

            if (BallMoving == false)
            {
                Ball.X = Pad.X + 40;
            }
            else
            {
                Ball.X += BallSpeed * dx;
                Ball.Y += BallSpeed * dy;

                if( Ball.Y > 600 )
                {
                    reinit();
                }
                else
                {
                    List<Rectangle> toRemove = new List<Rectangle>();
                    foreach (Rectangle block in Blocks)
                    {
                        if (instance_place(block, Ball))
                        {
                            toRemove.Add(block);
                            dy = -1*dy;
                            break;
                        }
                    }

                    foreach(Rectangle rectangle in toRemove)
                    {
                        Blocks.Remove(rectangle);
                    }


                    foreach (Rectangle wall in vWalls)
                    {
                        if (instance_place(wall, Ball))
                        {
                            dx *= -1;
                            break;
                        }
                    }

                    foreach (Rectangle wall in hWalls)
                    {
                        if (instance_place(wall, Ball))
                        {
                            dy *= -1;
                            break;
                        }
                    }

                    if (instance_place(Ball, Pad))
                    {
                        reinit();
                    }
                }
            }
        }

        public void ProcessInput( int xMouseLocation, bool isMousePressed )
        {
            Pad.X = xMouseLocation - 50;

            if (isMousePressed)
            {
                BallMoving = true;
            }
        }

        public bool instance_place( Rectangle r1, Rectangle r2 )
        {
            Rect rect1 = new Rect(r1.X, r1.Y, r1.Width, r1.Height);
            Rect rect2 = new Rect(r2.X, r2.Y, r2.Width, r2.Height);

            return rect1.IntersectsWith(rect2);
        }

    }
}
