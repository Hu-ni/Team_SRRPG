using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG.Model
{
    public class Inventory
    {
        //아이템 리스트를 만들어야함
        //공격 아이템과 방어 아이템은 같은 속성이 있고 다른 속성이 있음
        //아이템을 상속받아서 공격과 방어를 추가하여야함
        public List<Item> Items { get; set; } // 아이템 리스트
        public Inventory()
        {
            Items = new List<Item>()
            {
                new AttackItem(1, "검", "공격용 검", 100, 10),
                new AttackItem(2, "활", "원거리 공격용 활", 150, 15),
                new DefenseItem(3, "방패", "적의 공격을 막는 방패", 80, 5),
            };
        }
    }
}
