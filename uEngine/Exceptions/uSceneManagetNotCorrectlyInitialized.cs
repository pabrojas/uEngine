using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Exceptions
{
    public class uSceneManagetNotCorrectlyInitialized : Exception
    {
        public uSceneManagetNotCorrectlyInitialized() :
            base("La clase uSceneManager no tiene la escena activa correctamente configurada")
        {
        }
    }
}
