using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Exceptions;
using System.Drawing;

namespace uEngine.Managers
{
    class uFontPool
    {
        static private string FontsPath = "Assets/Fonts/";

        static private int FontIndex = 0;
        static private PrivateFontCollection FontCollection = new PrivateFontCollection(); 
        static private Dictionary<string, int> FontMap = new Dictionary<string, int>();

        public static void Load(string filename, string id)
        {
            if (File.Exists(FontsPath + filename))
            {
                if (FontMap.ContainsKey(id))
                {
                    throw new uResourceIdDuplicatedException(id);
                }
                else
                {
                    FontCollection.AddFontFile(FontsPath + filename);
                    FontMap.Add(id, FontIndex);
                    FontIndex++;
                }
            }
            else
            {
                throw new uResourceNotFoundException(FontsPath + filename);
            }
        }

        public static Font Get(string id, int size)
        {
            if (FontMap.ContainsKey(id))
            {
                int index = FontMap[id];
                return new Font(FontCollection.Families[index], size);
            }

            throw new uResourceIdNotFoundException(id);

        }

    }
}
