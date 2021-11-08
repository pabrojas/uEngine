using Sokoban.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace SokobanClases
{
    class GameplayScene : IScene
    {
        private int Width;
        private int Height;

        private bool keyUpPressed;
        private bool keyDownPressed;
        private bool keyLeftPressed;
        private bool keyRightPressed;

        private bool GoingToNextLevel;
        private int time;



        public GameplayScene(int width, int height)
        {
            Width = width;
            Height = height;
        }


        public bool IsAlive()
        {
            return true;
        }

        public IScene Next()
        {
            return null;
        }


        public void ProcessInput(int deltaTime)
        {
            SokobanWindow window = SokobanWindow.instance();
            SokobanModel model = window.Model;

            if(GoingToNextLevel == true)
            {
                return;
            }

            if (uInputManager.IsKeyPressed("Up"))
            {
                if (keyUpPressed == false)
                {
                    keyUpPressed = true;
                    model.MoveUp();
                }
            }
            else
            {
                keyUpPressed = false;
            }

            if (uInputManager.IsKeyPressed("Down"))
            {
                if (keyDownPressed == false)
                {
                    keyDownPressed = true;
                    model.MoveDown();
                }
            }
            else
            {
                keyDownPressed = false;
            }

            if (uInputManager.IsKeyPressed("Left"))
            {
                if (keyLeftPressed == false)
                {
                    keyLeftPressed = true;
                    model.MoveLeft();
                }
            }
            else
            {
                keyLeftPressed = false;
            }

            if (uInputManager.IsKeyPressed("Right"))
            {
                if (keyRightPressed == false)
                {
                    keyRightPressed = true;
                    model.MoveRight();
                }
            }
            else
            {
                keyRightPressed = false;
            }

        }

        public void GameUpdate(int deltaTime)
        {
            SokobanWindow window = SokobanWindow.instance();
            SokobanModel model = window.Model;

            if (model.Level.IsComplete())
            {
                GoingToNextLevel = true;
            }

            if (GoingToNextLevel)
            {
                time += deltaTime;
                if(time > 1000)
                {
                    model.GoToNextLevel();
                    GoingToNextLevel = false;
                    time = 0;
                }
            }


        }

        public void Render(Graphics g, int deltaTime)
        {
            SokobanWindow window = SokobanWindow.instance();
            SokobanModel model = window.Model;
            SokobanLevel level = model.Level;


            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, Width, Height);

            Image goal = uResourcesManager.GetImage("goal");
            Image wall = uResourcesManager.GetImage("wall");
            Image box = uResourcesManager.GetImage("box");
            Image boxOnGoal = uResourcesManager.GetImage("box-on-goal");
            Image floor = uResourcesManager.GetImage("floor");
            Image player = uResourcesManager.GetImage("player");

            if (level != null)
            {
                int rows = level.Rows;
                int cols = level.Cols;

                int offset = 100;
                int tileSize = (Width - 2 * offset) / cols;
                if (rows >= cols)
                {
                    tileSize = (Height - 2 * offset) / rows;
                }

                int offsetX = (Width - tileSize * cols) / 2;
                int offsetY = (Height - tileSize * rows) / 2;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        SokobanLevel.Tile tile = level.Board[i, j];
                     
                        int x = offsetX + tileSize * j;
                        int y = offsetY + tileSize * i;

                        if (tile == SokobanLevel.Tile.Floor)
                        {
                            g.DrawImage(floor, x, y, tileSize + 1, tileSize + 1);
                        }
                        else if (tile == SokobanLevel.Tile.Box)
                        {
                            g.DrawImage(floor, x, y, tileSize + 1, tileSize + 1);
                            if (level.Goals[i, j])
                            {
                                g.DrawImage(boxOnGoal, x, y, tileSize + 1, tileSize + 1);
                            }
                            else
                            {
                                g.DrawImage(box, x, y, tileSize + 1, tileSize + 1);
                            }
                        }
                        else if (tile == SokobanLevel.Tile.Wall)
                        {
                            g.DrawImage(floor, x, y, tileSize + 1, tileSize + 1);
                            g.DrawImage(wall, x, y, tileSize + 1, tileSize + 1);
                        }

                        if (level.Goals[i, j] && tile != SokobanLevel.Tile.Box)
                        {
                            g.DrawImage(goal, offsetX + tileSize * j, offsetY + tileSize * i, tileSize + 1, tileSize + 1);
                        }
                    }
                }


                g.DrawImage(player, offsetX + tileSize * level.PlayerCol, offsetY + tileSize * level.PlayerRow, tileSize, tileSize);

                
                if (GoingToNextLevel)
                {
                    Font fontMenu = uResourcesManager.GetFont("fuente-menu", 18);
                    Brush background = new SolidBrush(Color.FromArgb(2, 57, 64));
                    g.FillRectangle(background, new Rectangle(Width / 2 - 200, Height / 2 - 60, 400, 120));

                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    SolidBrush drawBrush = new SolidBrush(Color.White);

                    g.DrawString("Going to next level", fontMenu, drawBrush, new PointF(Width/2, Height/2 - 10), format);

                }
                

            }



        }
    }
}
