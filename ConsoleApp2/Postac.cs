using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Postac : Konsola
    {
        public int hp, atak, mana, gold;
        public string name;


        public Postac(int hp, int atak, int mana, int gold, string name)
        {
            this.hp = hp;
            this.atak = atak;
            this.mana = mana;
            this.gold = gold;
            this.name = name;
        }
        public Postac()
        {
        }

        public int walka(Postac potwor)
        {
            int wynik = starcie(potwor);
            if (wynik > 0)
            {
                komunikat($"zabierasz potworowi {potwor.gold} złota i pobierasz kawałki many z jego duszy");

                mana += potwor.mana;
                gold += potwor.gold;
                potwor.gold = 0;
                potwor.mana = 0;

            }
            if (wynik < 0)
            {
                komunikat("UMARŁEŚ!!!!");
                throw new Exception("UMARŁEŚ!!!");
            }
            return wynik;
        }
        int starcie(Postac potwor)
        {
            potwor.hp -= atak;
            if (potwor.hp < 0)
            {
                potwor.hp = 0;
                return 1;
            }
            hp -= potwor.atak;
            if (hp < 0)
            {
                hp = 0;
                return -1;
            }
            komunikat($"Potwór zadaje ci {potwor.atak}\nTy zadajesz mu {atak}");

            return 0;
        }
        public void staty()
        {
            
            Console.WriteLine($"    NAZWA    ────► {name}");
            Console.WriteLine($"    HP       ────► {hp} ");
            Console.WriteLine($"    ATTACK   ────► {atak} ");
            Console.WriteLine($"    MANA     ────► {mana} ");
            Console.WriteLine($"    GOLD     ────► {gold} ");
            Console.WriteLine("◄►───────────────────────────────◄►");
        }
    }
}
