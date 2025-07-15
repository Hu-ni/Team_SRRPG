using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Model
{
    public class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }
        public Item(int id, string name, string description, int cost = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
        }
    }
    public class AttackItem : Item
    {
        public int Attack { get; private set; }

        public AttackItem(int id, string name, string description, int cost, int attack)
            : base(id, name, description, cost)
        {
            Attack = attack;
        }
    }
    public class DefenseItem : Item
    {
        public int Defense { get; private set; }

        public DefenseItem(int id, string name, string description, int cost, int defense)
            : base(id, name, description, cost)
        {
            Defense = defense;
        }
    }
}
