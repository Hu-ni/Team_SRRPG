using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Team_SRRPG.Command.Interface;
using Team_SRRPG.Command.Scene;
using Team_SRRPG.Model;
using Team_SRRPG.Scene;
using Team_SRRPG.Scene.Interface;
using Team_SRRPG.Service;

namespace Team_SRRPG.Command.Factory
{
    public class CommandRepository : Singleton<CommandRepository>
    {
        private readonly Dictionary<GameCommandType, Func<IScene, CommandDescriptor, IGameCommand>> _map
            = new();

        private Random _random = new Random();

        // 외부에서 호출할 수 있는 등록 메서드
        public void Register(
            GameCommandType type,
            Func<IScene, CommandDescriptor, IGameCommand> creator)
        {
            _map[type] = creator;
        }

        public IGameCommand Create(IScene scene, CommandDescriptor desc)
        {
            if (!_map.TryGetValue(desc.Type, out var factory))
                throw new ArgumentException($"Unknown command type: {desc.Type}");
            return factory(scene, desc);
        }
    }
}
