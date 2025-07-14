using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.DTO
{
    public class StartSceneDTO : IEmptyDTO
    {
        public StartSceneDTO(string name, string description, string[] menus, int[] linked)
        {
            Name = name;
            Description = description;
            Menus = menus;
            Linked = linked;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Menus { get; set; }
        public int[] Linked {  get; set; }

    }
}
