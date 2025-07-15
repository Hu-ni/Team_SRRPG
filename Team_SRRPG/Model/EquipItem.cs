using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Model
{
    // 장비 아이템
    public class EquipItem : Item
    {
        public EquipItem(int id, string name, string description, int attack = 0, int defense = 0, int health = 0, int cost = 0, int luck = 0) 
                    : base(id, name, description, attack, defense, health, cost, luck)
                {
                }
    }
}
