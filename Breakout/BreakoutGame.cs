using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine;
using Breakout.Model;

namespace Breakout
{
    public class BreakoutGame : uGame
    {
        private BreakoutLogic game;

        private int xOffset;
        private int yOffset;
        private int courtWidth;
        private int courtHeight;
        private int lineWidth;

        private bool moveRight;
        private bool moveLeft;



        public BreakoutGame(int windowWidth, int windowHeight, int FPS) : base(windowWidth, windowHeight, FPS)
        {
            courtWidth = (int)(windowWidth * 0.9);
            courtHeight = (int)(windowHeight * 0.9);
            xOffset = (windowWidth - courtWidth) / 2;
            yOffset = (windowHeight - courtHeight) / 2;
            lineWidth = 10;

            moveLeft = false;
            moveRight = false;

            game = new BreakoutLogic(courtWidth, courtHeight, 10);
        }

        public override void GameUpdate()
        {
            if (moveLeft)
            {
                game.MoveLeft();
            }
            if (moveRight)
            {
                game.MoveRight();
            }
            

        }

        public override void ProcessInputs()
        {
            moveLeft = uInputManager.IsKeyPressed(Keys.Left);
            moveRight = uInputManager.IsKeyPressed(Keys.Right);
        }

        public override void Render(Graphics g)
        {
            //pinto los bordes
            g.FillRectangle(new SolidBrush(Color.White), xOffset - lineWidth, yOffset, lineWidth, courtHeight);
            g.FillRectangle(new SolidBrush(Color.White), xOffset + courtWidth, yOffset, lineWidth, courtHeight);
            g.FillRectangle(new SolidBrush(Color.White), xOffset - lineWidth, yOffset - lineWidth, courtWidth + lineWidth * 2, lineWidth);
            g.FillRectangle(new SolidBrush(Color.White), xOffset - lineWidth, yOffset + courtHeight, courtWidth + lineWidth * 2, lineWidth);

            //pinto el pad
            //g.FillRectangle(new SolidBrush(Color.GreenYellow),
            //    game.PlayerPad.X + xOffset,
            //    game.PlayerPad.Y + yOffset,
            //    game.PlayerPad.Width,
            //    game.PlayerPad.Height);


            //Image paddle = Image.FromFile(@"C:\Users\Pablo Rojas\Downloads\png\paddleBlu.png");
            Image paddle = uImagePool.Get("PlayerPad");
            g.DrawImage(paddle, game.PlayerPad.X + xOffset,
                game.PlayerPad.Y + yOffset,
                game.PlayerPad.Width,
                game.PlayerPad.Height);



            //pinto los bloques
            foreach (Block block in game.Blocks)
            {
                Image brick = uImagePool.Get(block.Background);
                g.DrawImage(brick,
                    block.Bounds.X + xOffset,
                    block.Bounds.Y + yOffset,
                    block.Bounds.Width,
                    block.Bounds.Height);
            }


        }
    }
}
