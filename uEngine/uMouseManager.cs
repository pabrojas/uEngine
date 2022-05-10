using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public static class uMouseManager
    {
        private static HashSet<MouseButtons> Buttons = new HashSet<MouseButtons>();
        private static Point Location = new Point();

        public static void Down(MouseButtons button)
        {
            if (!Buttons.Contains(button))
            {
                Buttons.Add(button);
            }
        }

        public static void Up(MouseButtons button)
        {
            Buttons.Remove(button);
        }

        public static bool IsPressed(MouseButtons button)
        {
            return Buttons.Contains(button);
        }

        public static void SetLocation(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
        }
    }
}
