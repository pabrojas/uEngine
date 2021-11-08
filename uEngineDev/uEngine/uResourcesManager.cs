using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine.Exceptions;
using System.Drawing.Text;

namespace uEngine
{
    public class uResourcesManager
    {
        static private string ImagesPath = "Assets/Images/";
        static private Dictionary<string, Image> Images = new Dictionary<string, Image>();

        static private string FontsPath = "Assets/Fonts/";
        static private int FontIndex = 0;
        static private PrivateFontCollection FontCollection = new PrivateFontCollection();
        static private Dictionary<string, int> FontMap = new Dictionary<string, int>();



        public static void LoadImage(string filename, string imageId)
        {
            if( File.Exists(ImagesPath + filename) )
            {
                if (Images.ContainsKey(imageId))
                {
                    throw new uResourceIdDuplicatedException(imageId);
                }
                else
                {
                    Image newImage = Image.FromFile(ImagesPath + filename);
                    Images.Add(imageId, newImage);
                }
            }
            else
            {
                throw new uResourceNotFoundException(ImagesPath + filename);
            }
        }

        public static Image GetImage(string id)
        {
            if(Images.ContainsKey(id))
            {
                return Images[id];
            }

            throw new uResourceIdNotFoundException(id);
            
        }

        public static void LoadFont(string filename, string fontId)
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

        public static Font GetFont(string id, int size)
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
