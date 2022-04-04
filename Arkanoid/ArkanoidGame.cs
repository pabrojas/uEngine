using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arkanoid.model;
using uEngine;

namespace Arkanoid
{
    class ArkanoidGame : uGame
    {
        private ArkanoidModel model;

        public ArkanoidGame(int windowWidth, int windowHeight, int targetFPS) : base(windowWidth, windowHeight, targetFPS)
        {
            model = new ArkanoidModel();
        }

        public override void GameUpdate()
        {
            model.Update();
        }

        public override void ProcessInput()
        {
            model.ProcessInput(MouseLocation.X, isMousePressed());
        }

        public override void Render(Graphics g)
        {
            model.Rectangle background = new model.Rectangle(0, 0, 800, 600, Color.White, Color.White);
            DrawRectangle(g, background);

            foreach (model.Rectangle block in model.Blocks)
            {
                DrawRectangle(g, block);
            }

            foreach (model.Rectangle wall in model.vWalls)
            {
                DrawRectangle(g, wall);
            }

            foreach (model.Rectangle wall in model.hWalls)
            {
                DrawRectangle(g, wall);
            }

            
            DrawBall(g, model.Ball);

            //DrawRectangle(g, model.Pad);
            Image image = uImageManager.Get("pad");
            g.DrawImage(image, model.Pad.X, model.Pad.Y, model.Pad.Width, model.Pad.Height);



        }

        private void DrawRectangle(Graphics g, model.Rectangle rectangle)
        {
            SolidBrush brush = new SolidBrush(rectangle.Background);
            Pen pen = new Pen(rectangle.Border);

            g.FillRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            g.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        private void DrawBall(Graphics g, model.Rectangle rectangle)
        {
            SolidBrush brush = new SolidBrush(rectangle.Background);
            Pen pen = new Pen(rectangle.Border);

            g.FillEllipse(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            g.DrawEllipse(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }
    }
}
