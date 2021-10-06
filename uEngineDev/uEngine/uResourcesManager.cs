using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uResourcesManager
    {
        static private Dictionary<string, Image> Images = new Dictionary<string, Image>();

        public static void LoadImage(string filename, string tagname)
        {
            Image newImage = Image.FromFile(filename);
            Images.Add(tagname, newImage);
        }

        public static Image GetImage(string tagname)
        {
            return Images[tagname];
        }
    }
}
