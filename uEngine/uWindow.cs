using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace uEngine
{
    public partial class uWindow : Form
    {
        private BufferedGraphicsContext GraphicManager;
        private BufferedGraphics ManagedBackBuffer;

        public Point MouseLocation;

        public bool mousePressed;

        public uWindow(int width, int height)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new System.Drawing.Size(width, height);

            GraphicManager = BufferedGraphicsManager.Current;
            GraphicManager.MaximumBuffer = new System.Drawing.Size(width + 1, height + 1);
            ManagedBackBuffer = GraphicManager.Allocate(CreateGraphics(), ClientRectangle);

            mousePressed = false;

            MouseMove += CustomMouseMove;
            MouseDown += CustomMouseDown;
            MouseUp += CustomMouseUp;

            KeyDown += CustomKeyDown;
            KeyUp += CustomKeyUp;
        }

        public Graphics GetGraphics()
        {
            ManagedBackBuffer.Graphics.Clear(Color.Black);
            return ManagedBackBuffer.Graphics;
        }

        public void Render()
        {
            ManagedBackBuffer.Render();
        }

        protected override void OnClosed(EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CustomMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseLocation = e.Location;
        }

        public bool isMousePressed()
        {
            return mousePressed;
        }

        private void CustomMouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
        }

        private void CustomMouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
        }

        private void CustomKeyDown(object sender, KeyEventArgs e)
        {
            Keys code = e.KeyCode;
            uKeyboardManager.Down(code);
        }

        private void CustomKeyUp(object sender, KeyEventArgs e)
        {
            Keys code = e.KeyCode;
            uKeyboardManager.Up(code);
        }

    }
}