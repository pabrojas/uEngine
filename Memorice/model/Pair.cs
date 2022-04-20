using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorice.Model
{
    public class Pair
    {
        public int i { private set; get; }
        public int j { private set; get; }

        public Pair(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
}
