using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.DTO;

namespace Team_SRRPG.Event
{
    public interface ISceneEventBus
    {
        void PublishSceneChange(int nextSceneIndex, IEmptyDTO dto);

        event Action<int, IEmptyDTO> OnSceneChange;
    }
}
