using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Model
{
    public class SceneData
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<OptionData> Options { get; set; }

        public SceneData()
        {
        }
    }
}
