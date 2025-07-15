using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.DTO;

namespace Team_SRRPG.Model
{
    public class SceneData
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> Linked { get; set; }
        public List<string> Menus { get; set; }

        public SceneData()
        {
        }
    }
}
