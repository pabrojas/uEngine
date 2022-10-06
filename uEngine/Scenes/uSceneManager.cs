using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uEngine.Exceptions;

namespace uEngine.Scenes
{
    public class uSceneManager
    {
        private static Dictionary<string, uScene> Scenes = new Dictionary<string, uScene>();

        private static string ActiveIndex = null;


        public static void Register( uScene scene, string index )
        {
            if (Scenes.ContainsKey(index))
            {
                throw new uSceneIndexDuplicatedException(index);
            }
            else
            {
                Scenes.Add(index, scene);
            }
        }

        public static uScene Get(string index)
        {
            return Scenes[index];
        }

        public static uScene GetActive()
        {
            if( ActiveIndex == null )
            {
                throw new uSceneManagetNotCorrectlyInitialized();
            }
            return Scenes[ActiveIndex];
        }

        public static void SetActive(string index)
        {
            if( !Scenes.ContainsKey(index) )
            {
                throw new uSceneManagerIndexNotFoundException(index);
            }
            ActiveIndex = index;
        }



    }
}
