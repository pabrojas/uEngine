using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Model
{
    public class BreakoutLogic
    {
        public Rectangle PlayerPad { get; private set; }
        public Rectangle Ball { get; private set; }
        public List<Block> Blocks { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Vidas { get; private set; }
        
        private int dx;
        private int dy;
        private int ballSpeed;
        private int PadSpeed;


        public BreakoutLogic(int width, int height, int padSpeed)
        {
            Width = width;
            Height = height;

            int padWidth = 100;
            int padHeight = 20;
            PlayerPad = new Rectangle(
                Width/2 - padWidth/2,
                Height - 2*padHeight,
                padWidth, 
                padHeight
                );
            PadSpeed = padSpeed;

            Blocks = new List<Block>();
            for (int i = 0; i < 9; i++)
            {
                Blocks.Add(new Block(10 + 100 * i, 100, 99, 19, "BrickBlue"));
            }
            for (int i = 0; i < 9; i++)
            {
                Blocks.Add(new Block(10 + 100 * i, 120, 99, 19, "BrickRed"));
            }


        }




        public void Update()
        {
            Ball = new Rectangle(
                Ball.X + ballSpeed * dx,
                Ball.Y + ballSpeed * dy,
                Ball.Width,
                Ball.Height
                );

            if( Ball.X <= 0 )
            {
                dx = 1;
            }
            else if( Ball.X + Ball.Width >= Width)
            {
                dx = -1;
            }

            if( Ball.Y <= 0 )
            {
                dy = 1;
            }
            else if( Ball.Y + Ball.Height >= Height )
            {
                //pierde una vida
                //reinicio la pelotita
            }

            //Me falta consultar los choques con los bloques
            //actualizar la direccion y eliminar el bloque


            //Me falta el choque con el PAD

        }

        public void MoveRight()
        {
            int newX = PlayerPad.X + PadSpeed;
            if( newX + PlayerPad.Width >= Width )
            {
                newX = Width - PlayerPad.Width;
            }

            PlayerPad = new Rectangle(
                newX,
                PlayerPad.Y,
                PlayerPad.Width,
                PlayerPad.Height
                );
        }

        public void MoveLeft()
        {
            int newX = PlayerPad.X - PadSpeed;
            if (PlayerPad.X - PadSpeed <= 0)
            {
                newX = 0;
            }

            PlayerPad = new Rectangle(
                newX,
                PlayerPad.Y,
                PlayerPad.Width,
                PlayerPad.Height
                );


        }
    }
}
