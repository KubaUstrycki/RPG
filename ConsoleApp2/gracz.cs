using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Gracz : Postac
    {
        int[,] postacie = { { 200, 60, 0, 15 }, { 150, 30, 150, 20 }, { 120, 40, 30, 35 }, { 9999999, 9999999, 9999999, 9999999 } };
        String[] nazwyPostaci = { "Wojownik", "Mag", "Bandyta", "BÓG" };
        public Gracz(int klasa)
        {
            
            hp = postacie[klasa, 0];
            atak = postacie[klasa, 1];
            mana = postacie[klasa, 2];
            gold = postacie[klasa, 3];
            name = nazwyPostaci[klasa];
        }

        void komunikat(string x)
        {
            staty();
            Console.WriteLine("\n◄►─────────────────────────────────────────────────────────────────────◄►");
            Console.WriteLine($"{x}  ");
            Console.WriteLine("◄►─────────────────────────────────────────────────────────────────────◄►");
            Console.ReadKey();
            Console.Clear();
            staty();
        }

        public  void heal()
        {
            if (mana >= 20)
            {
                hp += 15;
                mana -= 20;
                komunikat("Użyłeś Heala (+15 hp  -20 many)");

            }
            else
            {
                komunikat("Brak many");
            }
        }

        public  void megaHeal()
        {
            if (mana >= 100)
            {
                hp += 90;
                mana -= 100;
                komunikat("Użyłeś Mega Heala (+90 hp  -100 many)");
            }
            else
            {
                komunikat("Brak many");
            }
        }
        public  void boost()
        {
            if (mana >= 30)
            {
                hp += 10;
                atak += 30;
                mana -= 30;
                komunikat("Użyłeś Boosta (+10 hp   +30 dmg   -30 many)");
            }
            else
            {
                komunikat("Brak many");
            }
        }
        public  void superBoost()
        {
            if (mana >= 30)
            {
                hp += 100;
                atak += 1000;
                mana -= 400;
                komunikat("Użyłeś Super Sayanina (+100 hp   +1000 dmg   -400 many)");
            }
            else
            {
                komunikat("Brak many");
            }
        }
    }
}
