using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uEngine.Exceptions;

namespace uEngine
{
    public class uResourcesManager
    {
        static string Path = "Assets/Images/";
        static private Dictionary<string, Image> Images = new Dictionary<string, Image>();

        public static void LoadImage(string filename, string id)
        {
            if( File.Exists(Path + filename) )
            {
                if (Images.ContainsKey(id))
                {
                    throw new uResourceIdDuplicatedException(id);
                }
                else
                {
                    Image newImage = Image.FromFile(Path + filename);
                    Images.Add(id, newImage);
                }
            }
            else
            {
                throw new uResourceNotFoundException(Path + filename);
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
    }
}
