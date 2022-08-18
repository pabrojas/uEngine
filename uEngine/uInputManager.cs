using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uEngine
{
    public class uInputManager
    {
        private static HashSet<Keys> TeclasPresionadas = new HashSet<Keys>();

        public static void KeyDown(Keys key)
        {
            if (!TeclasPresionadas.Contains(key))
            {
                TeclasPresionadas.Add(key);
            }
        }
        public static void KeyUp(Keys key)
        {
            if (TeclasPresionadas.Contains(key))
            {
                TeclasPresionadas.Remove(key);
            }
        }
        public static bool IsKeyPressed(Keys key)
        {
            return TeclasPresionadas.Contains(key);
        }
    }
}
