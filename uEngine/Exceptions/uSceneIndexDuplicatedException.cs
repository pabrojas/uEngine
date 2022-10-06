using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uEngine.Exceptions
{
    public class uSceneIndexDuplicatedException : Exception
    {
        public uSceneIndexDuplicatedException(string index) :
            base("Ya existe una escena registrada con el índice: " + index)
        {
        }
    }
}
