using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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



        public void heal()
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

        public void megaHeal()
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
        public void boost()
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
        public void superBoost()
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

        public int ucieczka(Potwor potwor)
        {
            Random rnd = new Random();
            int ucieczka = rnd.Next(1, 6);
            for (int i = 0; i != 3; i++)
            {
                Console.Clear();
                Console.WriteLine("◄►─────────────────────────────◄►");
                Console.WriteLine($"           ZA {3 - i}");
                Console.WriteLine("◄►─────────────────────────────◄►");
                Thread.Sleep(new TimeSpan(0, 0, 1));
            }
            if (ucieczka == 2 || ucieczka == 5)
            {
                komunikat("Udaje ci się uciec");
                return 1; 
            }
            else
            {
                hp -= (potwor.atak * 2);
                komunikat("Nie udaje ci się uciec potwór zadaje ci podwójne obrażenia");
                return 0;
            }
        }

        public void zaklecia(bool isBoss)
        {
            int x;
            Console.WriteLine("\n◄►───────────────────────────────────────────────────────────────────────◄►");
            Console.WriteLine("    1 ────► heal                           +15 hp      -20 many");
            Console.WriteLine("    2 ────► Mega Heal                      +90 hp     -100 many)");
            Console.WriteLine("    3 ────► Boost              +30 dmg     +10 hp      -30 many)");
            if (isBoss)
            Console.WriteLine("    4 ────► Super Sayanin    +1000 dmg    +100 hp     -400 many)");
            Console.WriteLine("◄►───────────────────────────────────────────────────────────────────────◄►");
            x = getIntFromConsole();
            switch (x)
            {
                case 1:
                    heal();
                    break;
                case 2:
                    megaHeal();
                    break;
                case 3:
                    boost();
                    break;
                case 4:
                    if (isBoss)
                        superBoost();
                    else
                    {
                        komunikat("zły numer");
                    }
                    break;
                default:
                    komunikat("zły numer");
                    break;
            }
        }
        public void walka(Potwor potwor)
        {
            Console.WriteLine("Walka");
            walka((Postac)potwor);
        }
        public void staty()
        {
            Console.WriteLine("◄►─────────────GRACZ────────────◄►");
            base.staty();
        }
    }
}
