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

        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Linked { get; set; }
        public string[] Menus { get; set; }

        public SceneData()
        {
        }

        public SceneData(StartSceneDTO data)
        {
            Title = data.Name;
            Description = data.Description;
            Linked = data.Linked;
            Menus = data.Menus;
        }
    }
}
