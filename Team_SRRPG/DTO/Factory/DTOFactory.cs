using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.DTO.Factory
{
    public class DTOFactory : Singleton<DTOFactory>
    {
        public IEmptyDTO CreateSceneDTO(int selectedIdx)
        {
            switch (selectedIdx)
            {
                case 0:
                    break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
