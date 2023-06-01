using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Sklep : Konsola
    {
        Postac gracz;

        public Sklep(Postac gracz)
        {
            this.gracz = gracz;
        }

        public void sklep()
        {
            Console.WriteLine("\n◄►───────────────────────────────────────────────◄►");
            Console.WriteLine("    1 ────► heal (+25 hp)            5 złota");
            Console.WriteLine("    2 ────► lepsza broń (+20 ataku) 13 złota");
            Console.WriteLine("    3 ────► relaks w spa (+50 many)  8 złota");
            Console.WriteLine("    * ────► wyjdz z sklepu");
            Console.WriteLine("◄►───────────────────────────────────────────────◄►");
            int input = getIntFromConsole();
            switch (input)
            {
                case 1:
                    sklepHeal();
                    break;
                case 2:
                    sklepBron();
                    break;
                case 3:
                    sklepRelaksSpa();
                    break;
                default:
                    komunikat("Wychodzisz ze sklepu");
                    break;
            }
        }


        void sklepRelaksSpa()
        {
            const int CENA_SPA = 8;
            if (gracz.gold - CENA_SPA < 0)
            {
                komunikat($"Nie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {CENA_SPA - gracz.gold} złota");
            }
            else
            {
                gracz.gold -= CENA_SPA;
                gracz.mana += 50;
            }
        }

        void sklepBron()
        {
            const int CENA_BRON = 15;
            if ((gracz.gold - CENA_BRON) < 0)
            {
                komunikat($"Nie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {CENA_BRON - gracz.gold} złota");
            }
            else
            {
                gracz.gold -= CENA_BRON;
                gracz.atak += 20;
            }
        }

        void sklepHeal()
        {
            const int CENA_HEAL = 5;
            if ((gracz.gold - CENA_HEAL) < 0)
            {
                komunikat($"Nie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {CENA_HEAL - gracz.gold} złota");
            }
            else
            {
                gracz.gold -= CENA_HEAL;
                gracz.hp += 25;
            }
        }
    }
}
