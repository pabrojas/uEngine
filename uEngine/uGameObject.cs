using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine
{
    public class uGameObject
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Width { set; get; }
        public double Height { set; get; }
        public uSprite Sprite { set; get; }

        private List<uBoundingBox> BBoxes;

        public uGameObject(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Sprite = null;
            BBoxes = new List<uBoundingBox>();
        }

        public uGameObject(double x, double y, double width, double height, uSprite sprite)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Sprite = sprite;
            BBoxes = new List<uBoundingBox>();
        }

        public void ClearBBoxes()
        {
            BBoxes.Clear();
        }

        public void Add(uBoundingBox bbox)
        {
            BBoxes.Add(bbox);
        }

        public int CountBBoxes()
        {
            return BBoxes.Count;
        }

        public uBoundingBox GetBBox(int i)
        {
            return BBoxes[i];
        }

        public void RemoveBBox(int i)
        {
            BBoxes.RemoveAt(i);
        }

        public bool IntersectsWith(uGameObject ugo)
        {
            foreach (uBoundingBox bbox1 in BBoxes)
            {
                Rect r1 = new Rect(bbox1.X, bbox1.Y, bbox1.Width, bbox1.Height);

                foreach (uBoundingBox bbox2 in ugo.BBoxes)
                {
                    Rect r2 = new Rect(bbox2.X, bbox2.Y, bbox2.Width, bbox2.Height);

                    if(r1.IntersectsWith(r2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
