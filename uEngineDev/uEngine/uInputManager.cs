﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uEngine.managers;

namespace uEngine
{
    public class uInputManager
    {
        // Para mayor información de los nombres de las teclas revisar:
        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=net-5.0 
        static public bool IsKeyPressed(string key)
        {
            KeysConverter converter = new KeysConverter();
            Keys code = (Keys)converter.ConvertFromString(key);

            return uKeyboardManager.IsPressed(code);
        }
    }
}