using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Village
{
    public class Player
    {
        internal bool HP;
    }
    internal class Villages
    {

        static VillageSELECT villages()
        {
            string[] villages = new string[2];
            villages[0] = "1. 여관";
            villages[1] = "2.던전";


            Console.Clear();
            Console.WriteLine("수직적 마을에 오신 여러분 진심으로 환영합니다 \n");

            Console.WriteLine("[수직적 마을]\n");

            Console.WriteLine("1. 여관");
            Console.WriteLine("2. 던전 \n");

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");

            string Selection = Console.ReadLine();

            switch (Selection)
            {
                case "1":
                    Console.WriteLine("\n 여관으로 이동합니다");
                    Console.ReadLine();
                    return VillageSELECT.SELECTinn;
                    break;

                case "2":
                    Console.WriteLine("\n 던전으로 이동합니다");
                    Console.ReadLine();
                    return VillageSELECT.SELECTDungun;
                    break;

                default:
                    Console.WriteLine("\n 잘 못 입력하셨습니다");
                    Console.ReadLine();
                    return VillageSELECT.SELECTvillages;
                    break;

            }

        }

        static void inn()
        {

            static void innShop()
            {
                Console.WriteLine("모험가님 여관에 오신걸 환영해요");
                Console.WriteLine("무엇을 도와드릴까요?");

                Console.WriteLine("[포션 선택] \n");

                Console.WriteLine("1.HP회복");
                Console.WriteLine("2.MP회복\n");

                Console.WriteLine("0.나가기");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">>");

                Player Status = new Player();
                Console.WriteLine(Status.HP);

                
            }

        }
        static void Dunguns()
        {

            // 성준님 작업

        }


        enum VillageSELECT
        {
            SELECTvillages,
            SELECTinn,
            SELECTDungun,
            SELECTWrongslect,
        }

        
        static void Main(string[] args)
        {
            Player NewPlayer = new Player();
            

            while (true)
            {
                VillageSELECT selectCheck = villages();

                switch (selectCheck)
                {
                    case VillageSELECT.SELECTinn: inn();
                        break;

                    case VillageSELECT.SELECTDungun: Dunguns();
                        break;

                    case VillageSELECT.SELECTvillages: villages();
                        break;

                }
            }
        }

       
    }
}
