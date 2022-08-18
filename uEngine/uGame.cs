using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uEngine.GameLogic;

namespace uEngine
{
    //esta clase no sigue la regla del 1-1
    public class uGame
    {
        //Atributos de Pong
        private Pong pong;

        //atributo de pintado
        private int xOffset;
        private int yOffset;
        private int courtWidth;
        private int courtHeight;
        private int lineWidth;

        private bool PlayerWon;
        private bool ComputerWon;


        //Atributos de mi motor
        private int targetTime { get; set; }
        private uWindow MainWindow;

        public uGame(int windowWidth, int windowHeight, int FPS)
        {
            targetTime = 1000 / FPS;
            MainWindow = new uWindow(windowWidth, windowHeight);

            courtWidth = (int)(windowWidth * 0.9);
            courtHeight = (int)(windowHeight * 0.9);
            xOffset = (windowWidth - courtWidth) / 2;
            yOffset = (windowHeight - courtHeight) / 2;
            lineWidth = 10;
            
            pong = new Pong(courtWidth, courtHeight);
            PlayerWon = false;
            ComputerWon = false;
        }

        public void Start()
        {
            MainWindow.Show();
            Thread thread = new Thread(GameLoop);
            thread.Start();
        }


        private void GameLoop()
        {
            
            bool continuar = true;
            while(continuar)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                
                ProcessInputs();
                GameUpdate();
                Render(MainWindow.GetGraphics());
                //realiza el cambio del buffer
                MainWindow.Render();

                sw.Stop();

                int deltaTime = (int)sw.ElapsedMilliseconds;
                int sleepTime = targetTime - deltaTime;

                if( sleepTime < 0 )
                {
                    sleepTime = 1;
                }
                Thread.Sleep(sleepTime);

                if( MainWindow.IsDisposed )
                {
                    continuar = false;
                }

            }
            Environment.Exit(0);


        }


        public void ProcessInputs()
        {
            if (pong.IsEnded())
            {
                if (MainWindow.IsKeyPressed(Keys.Enter))
                {
                    pong = new Pong(courtWidth, courtHeight);
                    PlayerWon = false;
                    ComputerWon = false;
                }
                else if (MainWindow.IsKeyPressed(Keys.Escape))
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                if (MainWindow.IsKeyPressed(Keys.Up))
                {
                    pong.MovePlayerPadUp(lineWidth);
                }
                else if (MainWindow.IsKeyPressed(Keys.Down))
                {
                    pong.MovePlayerPadDown(lineWidth);
                }
            }
        }

        public void GameUpdate()
        {
            if( !pong.IsEnded() )
            {
                pong.Update();
            }
            else
            {
                if( pong.PlayerWon() )
                {
                    PlayerWon = true;
                    ComputerWon = false;
                }
                else if( pong.ComputerWon() )
                {
                    ComputerWon = true;
                    PlayerWon = false;
                }
            }
            
        }

        public void Render(Graphics g)
        {
            //borro el fondo y lo pinto negro
            g.FillRectangle(new SolidBrush(Color.Black), 
                0, 0, 
                MainWindow.ClientSize.Width, MainWindow.ClientSize.Height);

            DrawCourt(g);
            DrawRectangle(g, pong.PlayerPad);
            DrawRectangle(g, pong.ComputerPad);
            DrawEllipse(g, pong.Ball);
            DrawPoints(g);

            if(PlayerWon)
            {
                DrawWinningMessage(g, "Player");
            }
            else if(ComputerWon)
            {
                DrawWinningMessage(g, "Computador");
            }

        }

        private void DrawWinningMessage(Graphics g, string winner)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, xOffset + 50, yOffset + 50, courtWidth - 100, courtHeight - 100);


            SizeF stringSize;
            Font captionFont = new Font("Courier New", 36, FontStyle.Bold);
            Font winnerFont = new Font("Courier New", 48, FontStyle.Bold);
            Font messageFont = new Font("Courier New", 18, FontStyle.Bold);
            

            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;


            string caption = "El ganador es:";
            stringSize = g.MeasureString(caption, captionFont);
            PointF playerPoint = new PointF(xOffset + courtWidth / 2 - stringSize.Width / 2, 200);
            g.DrawString(caption, captionFont, drawBrush, playerPoint, drawFormat);

            
            stringSize = g.MeasureString(winner, winnerFont);
            PointF winnerPoint = new PointF(xOffset + courtWidth / 2 - stringSize.Width / 2, 300);
            g.DrawString(winner, winnerFont, drawBrush, winnerPoint, drawFormat);

            string message = "Presione <Enter> para continuar o <Esc> para salir";
            stringSize = g.MeasureString(message, messageFont);
            PointF messagePoint = new PointF(xOffset + courtWidth / 2 - stringSize.Width / 2, 500);
            g.DrawString(message, messageFont, drawBrush, messagePoint, drawFormat);




        }

        private void DrawCourt(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, xOffset, yOffset, courtWidth, lineWidth);
            g.FillRectangle(brush, xOffset, yOffset + courtHeight, courtWidth, lineWidth);
            
            g.FillRectangle(brush, xOffset, yOffset, lineWidth, courtHeight + lineWidth);
            g.FillRectangle(brush, xOffset + courtWidth, yOffset, lineWidth, courtHeight + lineWidth);

            int lineHeight = courtHeight / 10;

            for (int i = yOffset + lineHeight/4 + lineWidth/2; i < courtHeight; i += lineHeight)
            {
                g.FillRectangle(brush, xOffset + (courtWidth + lineWidth) / 2, i, lineWidth, lineHeight/2);
            }
        }

        private void DrawRectangle(Graphics g, GameLogic.Rectangle rectangle)
        {
            g.FillRectangle( new SolidBrush(Color.White),
                xOffset + rectangle.X, 
                yOffset + rectangle.Y,
                rectangle.Width,
                rectangle.Height);
        }

        private void DrawEllipse(Graphics g, GameLogic.Rectangle rectangle)
        {
            g.FillEllipse(new SolidBrush(Color.White),
                xOffset + rectangle.X,
                yOffset + rectangle.Y,
                rectangle.Width,
                rectangle.Height);
        }

        private void DrawPoints(Graphics g)
        {
            string player = (pong.PlayerPoints < 10 ? "0" : "") + pong.PlayerPoints;
            string computer = (pong.ComputerPoints < 10 ? "0" : "") + pong.ComputerPoints;

            Font drawFont = new Font("Courier New", 48, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;

            PointF playerPoint = new PointF(xOffset + courtWidth/2 - 100, 50.0F);
            g.DrawString(player, drawFont, drawBrush, playerPoint, drawFormat);

            PointF computerPoint = new PointF(xOffset + courtWidth / 2 + 20, 50.0F);
            g.DrawString(computer, drawFont, drawBrush, computerPoint, drawFormat);

        }

    }
}
