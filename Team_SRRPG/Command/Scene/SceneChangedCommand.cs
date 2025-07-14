using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;
using Team_SRRPG.DTO;
using Team_SRRPG.Event;

namespace Team_SRRPG.Command.Scene
{
    public class SceneChangedCommand : ICommand
    {
        private readonly int _nextIndex;
        private readonly ISceneEventBus _bus;

        public SceneChangedCommand(int nextIndex,
                                   ISceneEventBus bus)
        {
            _nextIndex = nextIndex;
            _bus = bus;
        }

        public void Execute()
        {
            var dto = _dtoFactory.CreateDto(_nextIndex);
            _bus.PublishSceneChange(_nextIndex, dto);
        }
    }
}
