using ConsoleApp2;
using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace gra
{
    class gra : Konsola
    {


        static int poziom = 0;
        static Postac gracz;
        static Postac potwor;
        static int mhp, mattack, mmana, mgold = 0;
        static String name = "";
        static String mname = "";


        
          


        public void poziomTrudnosci()
        {
            Console.WriteLine("\n◄►───────────WYBIERZ─POZIOM─TRUDNOŚCI─────────────◄►");
            Console.WriteLine("        1 ────► Łatwy");
            Console.WriteLine("        2 ────► Średni");
            Console.WriteLine("        3 ────► Trudny");
            Console.WriteLine("        4 ────► Imposible");
            Console.WriteLine("◄►──────────────────────────────────────────────────◄►");
            while (poziom == 0)
            {
                poziom = getIntFromConsole();
                if (poziom > 4 || poziom < 1)
                {
                    Console.WriteLine("Podaj poziom pomiędzy 1 a 4");
                    poziom = 0;
                }
            }
            Console.Clear();
        }


        public void wyborPostac()
        {

            Console.WriteLine("\n◄►─────────────────WYBIERZ─POSTAĆ─────────────────◄►");
            Console.WriteLine("        1 ────► Wojownik");
            Console.WriteLine("        2 ────► Mag");
            Console.WriteLine("        3 ────► Bandyta");
            Console.WriteLine("◄►──────────────────────────────────────────────────◄►");
            while (gracz == null)
            {
                int input = getIntFromConsole();
                if (input != 1 && input != 2 && input != 3 && input != 4)
                {
                    Console.WriteLine("zły numer");

                }
                else
                {
                    int x = input - 1;
                    gracz = new Gracz(x);
                }
            }
            gracz.staty();
        }

        public static void generowanieStatowPotwora()
        {
            
        }
        





        

        static void Main()
        {
            int round = 0;
            poziomTrudnosci();
            wyborPostac();
            while (hp > 0)
            {
                gracz.staty();
                Console.WriteLine("\n◄►────────────────CO─CHCESZ─ZROBIĆ────────────────◄►");
                Console.WriteLine("    1 ────► Idz do sklepu");
                Console.WriteLine("    2 ────► Idz na wyprawe");
                Console.WriteLine("◄►────────────────────────────────────────────────◄►");

                int inp = getIntFromConsole();
                if (inp == 1)
                {
                    sklep();
                }
                else if (inp == 2)
                {
                    potwor = new Potwor(poziom);
                    potwor.staty();

                    Random rnn = new Random();

                    int r = rnn.Next(8, 16);
                    if (round == r)
                    {
                        mhp = mhp * 4 + 50;
                        mattack = mattack * 3;
                        mmana = mmana * 3 + 100;
                        mgold = mgold * 3;
                        bossSpotkanie();
                        round = 0;
                    }
                    else
                    {
                        normalSpotkanie();
                        round += 1;
                    }
                }
            }
        }


        static void normalwalka()
        {
            gracz.staty();
            int runda = 1;
            Console.WriteLine("Walka");

            hp -= mattack;
            if (hp < 0) { hp = 0; }
            mhp -= attack;
            if (mhp < 0) { mhp = 0; }

            komunikat($"Potwór zadaje ci {mattack}\nTy zadajesz mu {attack}");

            if (hp == 0)
            {
                komunikat("UMARŁEŚ!!!!");
                return;
            }

            runda += 1;

            if (mhp == 0)
            {
                komunikat($"zabierasz potworowi {mgold} złota i pobierasz kawałki many z jego duszy");
                gold += mgold;
                mana += mmana;
            }
        }

        static int normalZaklecia()
        {
            int x;
            gracz.staty();
            Console.WriteLine("\n◄►───────────────────────────────────────────────────────────────────────◄►");
            Console.WriteLine("    1 ────► heal                           +15 hp      -20 many");
            Console.WriteLine("    2 ────► Mega Heal                      +90 hp     -100 many)");
            Console.WriteLine("    3 ────► Boost              +30 dmg     +10 hp      -30 many)");
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
                default:
                    komunikat("zły numer");
                    break;
            }

            return x;
        }

        static void normalUcieczka()
        {
            komunikat("Uciekasz");
            Random rnd = new Random();
            int ucieczka = rnd.Next(1, 6);
            if (ucieczka == 2 || ucieczka == 5)
            {
                komunikat("Udaje ci się uciec");
            }
            else
            {
                hp -= (mattack * 2);
                komunikat("Nie udaje ci się uciec potwór zadaje ci podwójne obrażenia");
            }
        }

        static void normalSpotkanie()
        {

            while (mhp > 0)
            {
                Console.WriteLine("\n◄►────────────────SPOTYKASZ─POTWORA────────────────◄►");
                Console.WriteLine("    1 ────► Walczysz");
                Console.WriteLine("    2 ────► Używasz Zaklęć");
                Console.WriteLine("    3 ────► Spróbuj ucieczki");
                Console.WriteLine("◄►────────────────────────────────────────────────◄►");

                int input = getIntFromConsole();
                if (input == 1)
                {
                    normalwalka();
                }
                if (input == 2)
                {
                    normalZaklecia();
                }
                if (input == 3)
                {
                    normalUcieczka();
                }
            }
        }
        private static void bossSpotkanie()
        {
            Console.WriteLine("\n◄►────────────────SPOTYKASZ─BOSSA────────────────◄►");
            Console.WriteLine("    1 ────► Walczysz");
            Console.WriteLine("    2 ────► Używasz Zaklęć");
            Console.WriteLine("    3 ────► Spróbuj ucieczki");
            Console.WriteLine("◄►───────────────────────────────────────────────◄►");


            int i = getIntFromConsole();
            if (i == 1)
            {
                bossWalka();

            }
            if (i == 2)
            {
                bossZaklecia();
            }
        }

        private static void bossWalka()
        {
            int runda = 1;
            komunikat("Walka!!!");
            while (mhp > 0)
            {

                komunikat($"Boss zadaje ci {mattack}");
                hp -= mattack;
                komunikat($"Ty zadajesz mu {attack}");
                mhp -= attack;

                if (hp <= 0)
                {
                    throw new Exception("Umarłeś");


                }
                komunikat($"zabierasz Bossowi {mgold} złota i pobierasz kawałki manny z jego duszy");
                gold += mgold;
                mana += mmana;
                runda += 1;


            }
        }

        private static void bossZaklecia()
        {
            int z = 0;
            gracz.staty();
            Console.WriteLine("\n◄►───────────────────────────────────────────────────────────────────────◄►");
            Console.WriteLine("    1 ────► heal                           +15 hp      -20 many");
            Console.WriteLine("    2 ────► Mega Heal                      +90 hp     -100 many)");
            Console.WriteLine("    3 ────► Boost              +30 dmg     +10 hp      -30 many)");
            Console.WriteLine("    4 ────► Super Sayanin    +1000 dmg    +100 hp     -400 many)");
            Console.WriteLine("◄►───────────────────────────────────────────────────────────────────────◄►");
            z = getIntFromConsole();
            if (z == 1)
            {
                heal();
            }
            if (z == 2)
            {
                megaHeal();
            }
            if (z == 3)
            {
                boost();
            }
            if (z == 4)
            {
                superBoost();
            }
            else
            {
                komunikat("zły numer");
            }
        }
    }
}