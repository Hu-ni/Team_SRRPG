using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Command.Interface;

namespace Team_SRRPG.Command.Scene
{
    public class CompositeCommand : IGameCommand
    {
        public string Name { get; }
        private readonly List<IGameCommand> _commands;

        public CompositeCommand(string name, List<IGameCommand> commands)
        {
            Name = name;
            _commands = commands;
        }

        public int? Execute()
        {
            foreach (var cmd in _commands)
                cmd.Execute();
            // 마지막으로 씬 전환이 필요하면
            //_onSceneChange(/* nextId */);
            return default;
        }
    }
}
