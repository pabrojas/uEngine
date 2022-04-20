using Memorice.Controller;
using Memorice.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine;

namespace Memorice.Scenes
{
    public class GameScene
    {

        private MemoriceLogic Logic;
        Pair FirstSelection;
        Pair SecondSelection;
        long LastMeasuredTime;

        bool finished;

        public GameScene()
        {
            Logic = new MemoriceLogic();
            FirstSelection = null;
            SecondSelection = null;

            LastMeasuredTime = long.MinValue;
            finished = false;
        }

        public long GetTime()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long millisecondsSinceEpoch = (long)t.TotalMilliseconds;

            return millisecondsSinceEpoch;
        }

        public bool IsFinished()
        {
            return finished;
        }

        public void GameUpdate()
        {
            if (FirstSelection != null && SecondSelection != null)
            {
                long currentTime = GetTime();

                long diff = currentTime - LastMeasuredTime;
                if (diff > 500)
                {
                    LastMeasuredTime = long.MinValue;

                    Card c1 = Logic.GetCard(FirstSelection.i, FirstSelection.j);
                    Card c2 = Logic.GetCard(SecondSelection.i, SecondSelection.j);

                    if (c1.Equals(c2))
                    {
                        FirstSelection = null;
                        SecondSelection = null;
                    }
                    else
                    {
                        Logic.SetStatus(FirstSelection.i, FirstSelection.j, CardStatus.Back);
                        Logic.SetStatus(SecondSelection.i, SecondSelection.j, CardStatus.Back);

                        FirstSelection = null;
                        SecondSelection = null;

                    }
                }

            }

            int sum = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CardStatus status = Logic.GetStatus(i, j);
                    if (status == CardStatus.Front)
                    {
                        sum++;
                    }
                }
            }
            if (sum == 36)
            {
                finished = true;
            }
        }

        public void ProcessInput(Point MouseLocation, bool isMousePressed)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CardStatus status = Logic.GetStatus(i, j);
                    if (status != CardStatus.Front)
                    {
                        Logic.SetStatus(i, j, CardStatus.Back);
                        if (!isMousePressed)
                        {
                            Rectangle rectangle = Parser.Get(i, j);
                            if (rectangle.Contains(MouseLocation))
                            {
                                Logic.SetStatus(i, j, CardStatus.Highlighted);
                            }
                        }
                        else
                        {
                            Rectangle rectangle = Parser.Get(i, j);
                            if (rectangle.Contains(MouseLocation))
                            {
                                Logic.SetStatus(i, j, CardStatus.Front);

                                if (FirstSelection == null)
                                {
                                    FirstSelection = new Pair(i, j);
                                    LastMeasuredTime = GetTime();
                                }
                                else if (SecondSelection == null)
                                {
                                    SecondSelection = new Pair(i, j);
                                    LastMeasuredTime = GetTime();
                                }

                            }
                        }
                    }

                }
            }
        }

        public void Render(Graphics g)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Rectangle rectangle = Parser.Get(i, j);
                    CardStatus status = Logic.GetStatus(i, j);
                    Card card = Logic.GetCard(i, j);

                    string assetName = card.ToString();

                    if (status == CardStatus.Back)
                    {
                        assetName = "back";
                    }
                    else if (status == CardStatus.Highlighted)
                    {
                        assetName = "highlighted";
                    }

                    Image image = uImageManager.Get(assetName);

                    g.DrawImage(image, rectangle);



                }
            }
        }
    }
}
