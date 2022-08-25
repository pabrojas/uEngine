using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Exceptions;

namespace uEngine
{
    public class uImageManager
    {
        static private string ImagesPath = "Assets/Images/";
        private static Dictionary<string, Image> Images = new Dictionary<string, Image>();


        public static void Load(string filename, string imageId)
        {
            if (File.Exists(ImagesPath + filename))
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

        public static Image Get(string id)
        {
            if (Images.ContainsKey(id))
            {
                return Images[id];
            }
            throw new uResourceIdNotFoundException(id);
        }
    }
}