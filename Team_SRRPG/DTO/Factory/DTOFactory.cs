using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Model;
using Team_SRRPG.Service;

namespace Team_SRRPG.DTO.Factory
{
    public class DTOFactory : Singleton<DTOFactory>
    {
        public IEmptyDTO CreateSceneDTO(int selectedIdx)
        {
            Player player = GameContext.Instance.Player;
            List<SceneData> sceneData = GameContext.Instance.sceneData;
            List<Item> itemList = GameContext.Instance.items;
            
            switch (selectedIdx)
            {
                case 0:
                    return new StartSceneDTO(sceneData[0].Title, sceneData[0].Description, sceneData[0].Menus, sceneData[0].Linked);
                    break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
