using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Team_SRRPG.Model
{
    public class Monster
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Hp { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Spd { get; private set; }
        public int Gold { get; private set; }
        public int Xp { get; private set; }

        public Monster(string name, int level, int hp, int atk, int def, int spd, int gold, int xp)
        {
            Name = name;
            Level = level;
            Hp = hp;
            Atk = atk;
            Def = def;
            Spd = spd;
            Gold = gold;
            Xp = xp;
        }
    }

}




