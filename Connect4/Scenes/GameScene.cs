using Connect4.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uEngine.Managers;
using uEngine;
using uEngine.Scenes;

namespace Connect4.Scenes
{
    public class GameScene : uScene
    {
        private Connect4Model Board;
        private int SelectedColumn;
        private bool PlayerTurn;

        private bool PreviouslyPressedRight;
        private bool PreviouslyPressedLeft;
        private bool PreviouslyPressedEnter;

        private bool Dropping;
        private int DroppingYStart;
        private int DroppingYEnd;

        private Random Generator;
        private int CpuTargetColumn;
        private int TotalTime;

        private int SumTime;
        private int MaxTime;
        private List<Color> Colors;
        private int Index;

        private int winner;


        public GameScene()
        {
            Board = new Connect4Model();
            Generator = new Random();
            PlayerTurn = true;
            SelectedColumn = 0;

            TotalTime = 0;

            PreviouslyPressedRight = false;
            PreviouslyPressedLeft = false;
            PreviouslyPressedEnter = false;

            Dropping = false;

            SumTime = 0;
            MaxTime = 100;

            Colors = new List<Color>();
            Colors.Add(Color.Aquamarine);
            Colors.Add(Color.BurlyWood);
            Colors.Add(Color.CadetBlue);
            Colors.Add(Color.DarkKhaki);
            Colors.Add(Color.Maroon);
            Colors.Add(Color.Moccasin);
            Index = 0;

        }


        public int getWinner()
        {
            return winner;
        }

        public void GameUpdate(int DeltaTime)
        {

            SumTime += DeltaTime;
            if (SumTime > MaxTime)
            {
                SumTime = 0;
                Index++;
                if (Index >= Colors.Count)
                {
                    Index = 0;
                }
            }


            if (PlayerTurn == true)
            {
                if (Dropping == true)
                {
                    DroppingYStart += 40;

                    if (DroppingYStart >= DroppingYEnd)
                    {
                        int row = Board.GetFreeRow(SelectedColumn);
                        Board.Drop(Token.Red, SelectedColumn);

                        //Si alguien ganó, fue el player
                        if (Board.hasWon(row, SelectedColumn) == true)
                        {
                            uSceneManager.SetActive("Ending");
                            winner = 1;
                        }


                        Dropping = false;
                        PlayerTurn = false;
                        int target;
                        do
                        {
                            target = Generator.Next(7);
                        }
                        while (!Board.HasAvailableSpace(target));
                        CpuTargetColumn = target;
                    }
                }
            }
            else
            {
                if (Dropping == false)
                {
                    TotalTime += DeltaTime;
                    if (TotalTime > 100)
                    {
                        if (SelectedColumn < CpuTargetColumn)
                        {
                            SelectedColumn++;
                        }
                        else if (CpuTargetColumn < SelectedColumn)
                        {
                            SelectedColumn--;
                        }
                        else
                        {
                            int targetRow = Board.GetFreeRow(SelectedColumn);
                            Dropping = true;
                            DroppingYStart = 900 - 639 - 50 + 27 - 150;
                            DroppingYEnd = 900 - 639 - 50 + 27 + targetRow * 99;
                        }
                        TotalTime = 0;
                    }
                }
                else
                {
                    DroppingYStart += 40;

                    if (DroppingYStart >= DroppingYEnd)
                    {
                        int row = Board.GetFreeRow(SelectedColumn);

                        Board.Drop(Token.Yellow, SelectedColumn);
                        Dropping = false;
                        PlayerTurn = true;

                        //Si alguien ganó, fue el compu
                        if (Board.hasWon(row, SelectedColumn) == true)
                        {
                            uSceneManager.SetActive("Ending");
                            winner = 2;
                        }

                    }
                }
            }
        }

        public void ProcessInputs()
        {
            if (PlayerTurn == true)
            {

                if (Dropping == false)
                {
                    if (uInputManager.IsKeyPressed(Keys.Right))
                    {
                        if (PreviouslyPressedRight == false)
                        {
                            uAudioPool.Play("bong");
                            SelectedColumn++;
                            if (SelectedColumn > 6)
                            {
                                SelectedColumn = 6;
                            }
                            PreviouslyPressedRight = true;
                        }
                    }
                    else
                    {
                        PreviouslyPressedRight = false;
                    }

                    if (uInputManager.IsKeyPressed(Keys.Left))
                    {
                        if (PreviouslyPressedLeft == false)
                        {
                            uAudioPool.Play("bong");
                            SelectedColumn--;
                            if (SelectedColumn < 0)
                            {
                                SelectedColumn = 0;
                            }
                            PreviouslyPressedLeft = true;
                        }
                    }
                    else
                    {
                        PreviouslyPressedLeft = false;
                    }

                    if (uInputManager.IsKeyPressed(Keys.Enter))
                    {
                        if (PreviouslyPressedEnter == false)
                        {
                            if (PlayerTurn == true)
                            {
                                if (Board.HasAvailableSpace(SelectedColumn))
                                {
                                    int targetRow = Board.GetFreeRow(SelectedColumn);
                                    Dropping = true;
                                    DroppingYStart = 900 - 639 - 50 + 27 - 150;
                                    DroppingYEnd = 900 - 639 - 50 + 27 + targetRow * 99;
                                }
                            }
                            PreviouslyPressedEnter = true;
                        }
                    }
                    else
                    {
                        PreviouslyPressedEnter = false;
                    }
                }
            }
        }

        public void Render(Graphics g)
        {
            //1300x900
            g.Clear(Color.White);

            int xToken00 = 50 + 27;
            int yToken00 = 900 - 639 - 50 + 27;

            Image red = uResourcesManager.GetImage("red");
            Image yellow = uResourcesManager.GetImage("yellow");

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Token token = Board.Get(i, j);
                    if (token == Token.Red)
                    {
                        g.DrawImage(red, xToken00 + j * 99, yToken00 + i * 99, 90, 90);
                    }
                    else if (token == Token.Yellow)
                    {
                        g.DrawImage(yellow, xToken00 + j * 99, yToken00 + i * 99, 90, 90);
                    }
                    else if (token == Token.Glow)
                    {
                        g.FillRectangle(new SolidBrush(Colors[Index]), xToken00 + j * 99, yToken00 + i * 99, 90, 90);
                    }
                }
            }

            if (Dropping == true)
            {
                if (PlayerTurn == true)
                {
                    g.DrawImage(red, xToken00 + SelectedColumn * 99, DroppingYStart, 90, 90);
                }
                else
                {
                    g.DrawImage(yellow, xToken00 + SelectedColumn * 99, DroppingYStart, 90, 90);
                }
            }
            else
            {
                if (PlayerTurn == true)
                {
                    g.DrawImage(red, xToken00 + SelectedColumn * 99, yToken00 - 150, 90, 90);
                }
                else
                {
                    g.DrawImage(yellow, xToken00 + SelectedColumn * 99, yToken00 - 150, 90, 90);
                }
            }

            //738x639
            Image board = uResourcesManager.GetImage("board");
            g.DrawImage(board, 50, 900 - 639 - 50, 738, 639);




            Font titleFont = uResourcesManager.GetFont("font", 48);
            SizeF size = g.MeasureString("Turno", titleFont);
            g.DrawString("Turno", titleFont, new SolidBrush(Color.Black), 1000 - size.Width / 2, 100);

            Font turnFont = uResourcesManager.GetFont("blocks", 32);
            if (PlayerTurn)
            {
                size = g.MeasureString("Player", turnFont);
                g.DrawString("Player", turnFont, new SolidBrush(Color.Black), 1000 - size.Width / 2, 200);
            }
            else
            {
                string cpu = "Computador";
                size = g.MeasureString(cpu, turnFont);
                g.DrawString(cpu, turnFont, new SolidBrush(Color.Black), 1000 - size.Width / 2, 200);
            }
        }
    }
}
