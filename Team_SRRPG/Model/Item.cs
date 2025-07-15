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
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Health { get; private set; }
        public int Luck { get; private set; }
        public int Cost { get; private set; }
        public bool IsEquipped { get; set; } = false; 
        public bool IsPurchased { get; set; } = false;

        public Item(int id, string name, string description, int attack = 0, int defense = 0, int health = 0, int luck = 0, int cost = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            Attack = attack;
            Defense = defense;
            Health = health;
            Cost = cost;
            Luck = luck;
            IsEquipped = false;
            IsPurchased = false;
        }
    }
}
