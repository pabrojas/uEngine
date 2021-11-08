using Sokoban.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace Sokoban.Views
{
    public class GameplayScreen
    {
        private int Width;
        private int Height;

        private SokobanModel Model { set; get; }

        private bool KeyUpPressed;
        private bool KeyDownPressed;
        private bool KeyLeftPressed;
        private bool KeyRightPressed;

        private bool GoingToNextLevel;
        private int Time;


        public GameplayScreen(SokobanModel model, int width, int height)
        {
            Width = width;
            Height = height;
            Model = model;

            KeyUpPressed = false;
            KeyDownPressed = false;
            KeyLeftPressed = false;
            KeyRightPressed = false;

            GoingToNextLevel = false;
            Time = 0;
        }

        public void ProcessInput()
        {
            if(Model.Level.IsComplete() && GoingToNextLevel == false)
            {
                GoingToNextLevel = true;
                Time = 0;
            }

            if (!GoingToNextLevel)
            {

                if (uInputManager.IsKeyPressed("Up"))
                {
                    if (KeyUpPressed == false)
                    {
                        KeyUpPressed = true;
                        Model.MoveUp();
                    }
                }
                else
                {
                    KeyUpPressed = false;
                }

                if (uInputManager.IsKeyPressed("Down"))
                {
                    if (KeyDownPressed == false)
                    {
                        KeyDownPressed = true;
                        Model.MoveDown();
                    }
                }
                else
                {
                    KeyDownPressed = false;
                }

                if (uInputManager.IsKeyPressed("Left"))
                {
                    if (KeyLeftPressed == false)
                    {
                        KeyLeftPressed = true;
                        Model.MoveLeft();
                    }
                }
                else
                {
                    KeyLeftPressed = false;
                }

                if (uInputManager.IsKeyPressed("Right"))
                {
                    if (KeyRightPressed == false)
                    {
                        KeyRightPressed = true;
                        Model.MoveRight();
                    }
                }
                else
                {
                    KeyRightPressed = false;
                }
            }

        }

        public void GameUpdate(int deltaTime)
        {
            if (GoingToNextLevel)
            {
                Console.Write("updating... ");
                Time += deltaTime;
                Console.WriteLine(Time);
                if (Time >= 5000)
                {
                    GoingToNextLevel = false;
                    Model.GoToNextLevel();
                    Console.WriteLine("\tNext");
                }
            }
        }

        public void Render(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, Width, Height);

            Image goal = uResourcesManager.GetImage("goal");
            Image wall = uResourcesManager.GetImage("wall");
            Image box = uResourcesManager.GetImage("box");
            Image boxOnGoal = uResourcesManager.GetImage("box-on-goal");
            Image floor = uResourcesManager.GetImage("floor");
            Image player = uResourcesManager.GetImage("player");

            if (Model.Level != null)
            {
                int rows = Model.Level.Rows;
                int cols = Model.Level.Cols;

                int offset = 100;
                int tileSize = (Width - 2 * offset) / cols;
                if(rows >= cols)
                {
                    tileSize = (Height - 2 * offset) / rows;
                }

                int offsetX = (Width - tileSize * cols) / 2;
                int offsetY = (Height - tileSize * rows) / 2;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        SokobanLevel.Tile tile = Model.Level.Board[i, j];
                        int x = offsetX + tileSize * j;
                        int y = offsetY + tileSize * i;


                        if (tile == SokobanLevel.Tile.Floor)
                        {
                            g.DrawImage(floor, x, y, tileSize + 1, tileSize + 1);
                        }
                        else if (tile == SokobanLevel.Tile.Box)
                        {
                            g.DrawImage(floor, x, y, tileSize + 1, tileSize + 1);
                            if (Model.Level.Goals[i, j])
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

                        if (Model.Level.Goals[i, j] && tile != SokobanLevel.Tile.Box)
                        {
                            g.DrawImage(goal, offsetX + tileSize * j, offsetY + tileSize * i, tileSize+1, tileSize+1);
                        }
                    }
                }

                
                g.DrawImage(player, offsetX + tileSize * Model.Level.PlayerCol, offsetY + tileSize * Model.Level.PlayerRow, tileSize, tileSize);

                if(GoingToNextLevel)
                {
                    Brush background = new SolidBrush(Color.FromArgb(2, 57, 64));
                    g.FillRectangle(background, new Rectangle(Width / 2 - 200, Height / 2 - 60, 400, 120));

                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    SolidBrush drawBrush = new SolidBrush(Color.White);

                    g.DrawString("Start", fontMenu, selected == 0 ? menuBrush : drawBrush, new PointF(Width - 100, 560), format);

                }


            }
        }
    }
}
