using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Exceptions;

namespace uEngine
{
    public class uFontManager
    {
        static private string FontsPath = "Assets/Fonts/";
        static private int FontIndex = 0;
        static private PrivateFontCollection FontCollection = new PrivateFontCollection();
        static private Dictionary<string, int> FontMap = new Dictionary<string, int>();

        public static void Load(string filename, string fontId)
        {
            if (File.Exists(FontsPath + filename))
            {
                if (FontMap.ContainsKey(fontId))
                {
                    throw new uResourceIdDuplicatedException(fontId);
                }
                else
                {
                    FontCollection.AddFontFile(FontsPath + filename);
                    FontMap.Add(fontId, FontIndex);
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
