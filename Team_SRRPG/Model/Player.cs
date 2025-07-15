using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_SRRPG.Service;

namespace Team_SRRPG.Model
{
    public enum Job
    {
        Warrior, // 전사
        Mage,    // 마법사
        Archer   // 궁수
    }
    public class Player
    {
        public string Name { get; set; } // 플레이어 이름
        public Job Job { get; set; } // 플레이어 직업
        public int Level { get; set; } // 플레이어 레벨
        public int Experience { get; set; } // 플레이어 경험치
        public int Attack { get; set; } // 플레이어 공격력
        public int Defense { get; set; } // 플레이어 방어력
        public int health = 100; // 플레이어 체력
        public int Mana { get; set; } // 플레이어 마나
        public int Gold { get; set; } // 플레이어 소지 금액
        public int Luck { get; set; } // 플레이어 행운
        public Player(string name, Job job, int level = 1, int exp = 0, int mana = 50, 
            int gold = 1000, int luck = 0, int attack = 0, int defense = 0, int health = 0)
        {
            Name = name;
            Job = job;
            Level = level;
            Experience = exp;
            Mana = mana;
            Gold = gold;
            Luck = luck;
            Attack = attack;
            Defense = defense;
            this.health = health;
        }
        //인벤토리에서 장착한 아이템의 공격력 혹은 방어력과
        //내 공격력 혹은 방어력의 합을 나타내는 토탈 스탯을 구현하는 메서드
        
        //public int TotalAttack
    //    {
    //        get
    //        {
    //            return Attack + inventory.Items.Where(i => i.IsEquipped)
    //                .Sum(i => i.Items.Attack);
    //        }
    //    }
    //    public int TotalDefense
    //    {
    //        get
    //        {
    //            return Defense + inventory.Items.Where(item => item is DefenseItem)
    //                .Sum(item => ((DefenseItem)item).Defense);
    //        }
    //    }
    }
}