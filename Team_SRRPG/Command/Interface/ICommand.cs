using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Event;

namespace Team_SRRPG.Command.Interface
{
    public interface ICommand
    {
        public string Name {  get; }
        public void Execute();

    }
}
