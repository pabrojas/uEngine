using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uEngine.managers
{
    public class uKeyboardManager
    {
        private static HashSet<Keys> PressedKeys = new HashSet<Keys>();

        public static void Down(Keys code)
        {
            if (!PressedKeys.Contains(code))
            {
                PressedKeys.Add(code);
            }
        }

        public static void Up(Keys code)
        {
            PressedKeys.Remove(code);
        }

        public static bool IsPressed(Keys code)
        {
            return PressedKeys.Contains(code);
        }


    }
}
