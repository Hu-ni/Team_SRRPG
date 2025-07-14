using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.DTO;

namespace Team_SRRPG.Event
{
    public class SceneEventBus : ISceneEventBus
    {
        public event Action<int, IEmptyDTO> OnSceneChange;

        public void PublishSceneChange(int nextSceneIndex, IEmptyDTO dto)
        {
            OnSceneChange?.Invoke(nextSceneIndex, dto);
        }
    }
}
