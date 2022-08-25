using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Exceptions
{
    public class uResourceIdDuplicatedException : Exception
    {
        public uResourceIdDuplicatedException(string id) :
            base("El identificador \"" + id + "\" ya se encuentra especificado, utilice otro identificador")
        {
        }
    }
}