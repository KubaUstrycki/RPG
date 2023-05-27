using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Postac
    {
        public int hp, atak, mana, gold;
        protected string name;

      
        public Postac(int hp, int atak, int mana, int gold, string name)
        {
            this.hp = hp;
            this.atak = atak;
            this.mana = mana;
            this.gold = gold;
            this.name = name;
        }

        protected Postac()
        {
        }

        int walka(Postac p)
        {
            int wynik = starcie(p);

    
            
            if (wynik > 0)
            {
                mana += p.mana;
                gold += p.gold;
                p.gold = 0; 
                p.mana = 0;

            }
            if (wynik < 0)
            {
                p.mana += mana;
                p.gold += gold;
                gold = 0;
                mana = 0;
            }
            return wynik;
        }
        int starcie(Postac p)
        {
            p.hp -= atak;
            if (p.hp < 0)
            {
                p.hp = 0;
                return 1;
            }

            hp -= p.atak;
            if (hp < 0)
            {
                hp = 0;
                return -1;
            }



            
            return 0;
        }
        public void staty()
        {

            Console.Clear();
            Console.WriteLine("◄►───────────────────────────────◄►");
            Console.WriteLine($"    NAZWA    ────► {name}");
            Console.WriteLine($"    HP       ────► {hp} ");
            Console.WriteLine($"    ATTACK   ────► {atak} ");
            Console.WriteLine($"    MANA     ────► {mana} ");
            Console.WriteLine($"    GOLD     ────► {gold} ");
            Console.WriteLine("◄►───────────────────────────────◄►");
        }
}
