using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Team_SRRPG.Model
{
    public class Dungeon
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Difficult { get; private set; }

        // 던전 클리어 보상
        public int Gold { get; private set; }
        [XmlArray("ItemIds")]
        [XmlArrayItem("ID")]
        public List<int> ItemIds { get; private set; }
    }
}
