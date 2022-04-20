using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Memorice.Model;

namespace Memorice.Controller
{
    public class Parser
    {
        static private Dictionary<Pair, Rectangle> Locations = new Dictionary<Pair, Rectangle>();

        static public void Initialize()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Rectangle rectangle = new Rectangle(243 + i * 93, 34 + j * 120, 73, 100);
                    Pair pair = new Pair(i, j);
                    Locations.Add(pair, rectangle);
                }
            }
        }

        static public Rectangle Get(int i, int j)
        {
            foreach( Pair pair in Locations.Keys)
            {
                if( pair.i == i && pair.j == j)
                {
                    return Locations[pair];
                }
            }


            return new Rectangle(0, 0, 0, 0);
        }

    }
}
