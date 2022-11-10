using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uSprite
    {
        private List<Image> frames;
        private int index;
        private int delta;

        private int elapsedTime;

        public uSprite(int delta)
        {
            this.frames = new List<Image>();
            this.index = 0;
            this.delta = delta;
            this.elapsedTime = 0;
        }

        public void Add(Image frame)
        {
            this.frames.Add(frame);
        }

        public Image Current()
        {
            return this.frames[this.index];
        }

        public void Update(int DeltaTime)
        {
            this.elapsedTime += DeltaTime;

            if (this.elapsedTime > this.delta)
            {
                this.elapsedTime = 0;
                this.index++;
                if (this.index >= this.frames.Count)
                {
                    this.index = 0;
                }
            }
        }
    }
}
