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
        private List<Keys> pressedKeys;

        public uWindow(int clientWidth, int clientHeight)
        {
            pressedKeys = new List<Keys>();
            
            ClientSize = new Size(clientWidth, clientHeight);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            KeyDown += CustomKeyDown;
            KeyUp += CustomKeyUp;


        }

        private void CustomKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if(!pressedKeys.Contains(key))
            {
                pressedKeys.Add(key);
            }
        }
        private void CustomKeyUp(object sender, KeyEventArgs e)
        {
            if(pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Remove(e.KeyCode);
            }
        }
        public bool IsKeyPressed(Keys key)
        {
            return pressedKeys.Contains(key);
        }

    }
}
