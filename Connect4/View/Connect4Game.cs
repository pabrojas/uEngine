using Connect4.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uEngine;
using uEngine.Managers;

namespace Connect4.View
{
    public class Connect4Game : uGame
    {
        private Connect4Model Board;
        private bool PlayerTurn;
        private int SelectedColumn;

        private bool PreviouslyPressedRight;
        private bool PreviouslyPressedLeft;
        private bool PreviouslyPressedEnter;

        private bool Dropping;
        private int DroppingYStart;
        private int DroppingYEnd;

        public Connect4Game(int windowWidth, int windowHeight, int FPS) : base(windowWidth, windowHeight, FPS)
        {
            Board = new Connect4Model();
            PlayerTurn = true;
            SelectedColumn = 0;

            PreviouslyPressedRight = false;
            PreviouslyPressedLeft = false;
            PreviouslyPressedEnter = false;

            Dropping = false;
        }

        public override void GameUpdate()
        {
            if( Dropping == true )
            {
                DroppingYStart += 40;

                if (DroppingYStart >= DroppingYEnd)
                {
                    Board.Drop(Token.Red, SelectedColumn);
                    Dropping = false;
                }
            }
        }

        public override void ProcessInputs()
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
                        if (Board.HasAvailableSpace(SelectedColumn))
                        {
                            //Board.Drop(Token.Red, SelectedColumn);
                            int targetRow = Board.GetFreeRow(SelectedColumn);
                            Dropping = true;
                            DroppingYStart = 900 - 639 - 50 + 27 - 150;
                            DroppingYEnd = 900 - 639 - 50 + 27 + targetRow * 99;
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

        public override void Render(Graphics g)
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
                    if( token == Token.Red )
                    {
                        g.DrawImage(red, xToken00 + j * 99, yToken00 + i * 99, 90, 90);
                    }
                    else if( token == Token.Yellow )
                    {
                        g.DrawImage(yellow, xToken00 + j * 99, yToken00 + i * 99, 90, 90);
                    }
                }
            }

            if (Dropping == true)
            {
                g.DrawImage(red, xToken00 + SelectedColumn * 99, DroppingYStart, 90, 90);
            }
            else
            {
                if (PlayerTurn == true)
                {
                    g.DrawImage(red, xToken00 + SelectedColumn * 99, yToken00 - 150, 90, 90);
                }
            }

            //738x639
            Image board = uResourcesManager.GetImage("board");
            g.DrawImage(board, 50, 900 - 639 - 50, 738, 639);

            





        }
    }
}
