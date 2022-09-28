using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Managers
{
    public class uResourcesManager
    {
        public static void LoadImage(string filename, string imageId)
        {
            uImagePool.Load(filename, imageId);
        }

        public static Image GetImage(string imageId)
        {
            return uImagePool.Get(imageId);
        }
    }
}
