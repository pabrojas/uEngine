using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uSingleSprite : uSprite
    {
        private Image image;

        public uSingleSprite(Image image)
        {
            this.image = image;
        }


        public Image Current()
        {
            return this.image;
        }

        public void Update(int DeltaTime)
        {
        }
    }
}
