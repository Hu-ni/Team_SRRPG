﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Service;

namespace Team_SRRPG.Model
{
    public class Player
    {
        public string Name { get; set; } // 플레이어 이름
        public string Job { get; set; } // 플레이어 직업
        public int Level { get; set; } // 플레이어 레벨
        public int Experience { get; set; } // 플레이어 경험치
        public int Health { get; set; } // 플레이어 체력
        public int Attack { get; set; } // 플레이어 공격력
        public int Defense { get; set; } // 플레이어 방어력
        public int Mana { get; set; } // 플레이어 마나
        public int Gold { get; set; } // 플레이어 소지 금액
        public int Luck { get; set; } // 플레이어 행운
        public Player(string name, string job, int level = 1, int exp = 0, int health = 100, 
            int mana = 50, int gold = 1000, int luck = 0, int attack = 0, int defense = 0)
        {
            Name = name;
            Job = job;
            Level = level;
            Experience = exp;
            Health = health;
            Mana = mana;
            Gold = gold;
            Luck = luck;
            Attack = attack;
            Defense = defense;
        }
        public int GetTotalAttack(Inventory inventory)
        {
            return Attack + inventory.GetTotalAttackBonus();
        }
        public int GetTotalDefense(Inventory inventory)
        {
            return Defense + inventory.GetTotalDefenseBonus();
        }
    }
}
