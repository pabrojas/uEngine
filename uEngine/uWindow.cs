using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uWindow : Form
    {

        private BufferedGraphicsContext GraphicManager;
        private BufferedGraphics ManagedBackBuffer;

        public uWindow(int clientWidth, int clientHeight)
        {

            ClientSize = new Size(clientWidth, clientHeight);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            GraphicManager = BufferedGraphicsManager.Current;
            GraphicManager.MaximumBuffer = new Size(clientWidth + 1, clientHeight + 1);
            ManagedBackBuffer = GraphicManager.Allocate(CreateGraphics(), ClientRectangle);

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

        private void CustomKeyDown(object sender, KeyEventArgs e)
        {
            uInputManager.KeyDown(e.KeyCode);
        }
        private void CustomKeyUp(object sender, KeyEventArgs e)
        {
            uInputManager.KeyUp(e.KeyCode);
        }

    }
}

