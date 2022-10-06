using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Exceptions
{
    public class uSceneManagerIndexNotFoundException : Exception
    {
        public uSceneManagerIndexNotFoundException(string index) :
            base("El índice : " + index + " no se ha registrado en uSceneManager" )
        {
        }
    }
}
