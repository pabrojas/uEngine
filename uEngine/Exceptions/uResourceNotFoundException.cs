using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Exceptions
{
    public class uResourceNotFoundException : Exception
    {
        public uResourceNotFoundException(string filename) : base("El archivo \"" + filename + "\" no se encuentra")
        {
        }
    }
}