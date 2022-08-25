using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Exceptions
{
    public class uResourceIdNotFoundException : Exception
    {
        public uResourceIdNotFoundException(string id) : base("El identificador \"" + id + "\" no existe")
        {
        }
    }
}