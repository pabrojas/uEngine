using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.sprites
{
    public class uAnimationByFramesSprite : uSprite
    {
        private List<Image> frames;
        private int index;
        private int frameLength;
        private int time;

        public uAnimationByFramesSprite(int width, int height, int frameLength) : base(width, height)
        {
            frames = new List<Image>();
            index = 0;
            this.frameLength = frameLength;
            time = 0;
        }

        public void AddFrame(Image image)
        {
            frames.Add(image);
        }


        public override Image GetCurrentFrame()
        {
            return frames[index];
        }

        public override void Update(int deltaTime)
        {
            time += deltaTime;
            if( time > frameLength )
            {
                time = 0;
                index++;
                if( index >= frames.Count )
                {
                    index = 0;
                }
            }
        }
    }
}
