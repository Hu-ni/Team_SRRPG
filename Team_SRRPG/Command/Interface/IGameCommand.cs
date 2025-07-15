using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Command.Interface
{
    public interface IGameCommand
    {
        public string Name {  get; }
        public int? Execute();

    }
}
