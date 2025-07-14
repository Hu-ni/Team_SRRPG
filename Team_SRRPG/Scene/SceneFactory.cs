using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.DTO;
using Team_SRRPG.Scene.Interface;

namespace Team_SRRPG.Scene
{
    public class SceneFactory : Singleton<SceneFactory>
    {
        public IScene Create(int index, IEmptyDTO data)
        {
            //TODO: Scene-index int->Enum 형 변환
            switch (index)
            {
                case 0: return new StartScene(data); break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
