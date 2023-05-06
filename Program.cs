using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace gra
{
    class gra
    {
        static int[,] postacie = { { 200, 60, 0, 15 }, { 150, 30, 150, 20 }, { 120, 40, 30, 35 }, { 9999999, 9999999, 9999999, 9999999 } };
        static String[] nazwyPostaci = { "Wojownik", "Mag", "Bandyta", "BÓG" };

        static int hp, attack, mana, gold = 0;
        static int mhp, mattack, mmana, mgold = 0;
        static int bhp, battack, bmana, bgold = 0;
        static String name = "";

        static void komunikat(string x)
        {
            Console.Clear();
            Console.WriteLine(x);
            Console.ReadKey();
            Console.Clear();
        }

        static int getIntFromConsole()
        {
            int x = -1;
            while (x == -1)
            {
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wpisz cyfrę.");
                }
            }
            return x;
        }

        public static void wyborPostac()
        {
            hp = 0;

            while (hp == 0)
            {
                Console.WriteLine("Wybor postaci: \n Wojownik - 1 \n Mag - 2 \n bandyta - 3 ");
                int input = getIntFromConsole();
                if (input != 1 && input != 2 && input != 3 && input != 4)
                {
                    komunikat("zły numer");
                }
                else
                {
                    int x = input - 1;
                    hp = postacie[x, 0];
                    attack = postacie[x, 1];
                    mana = postacie[x, 2];
                    gold = postacie[x, 3];
                    name = nazwyPostaci[x];
                }
            }
        }

        public static void generowanieStatowPotwora()
        {
            Random rnd = new Random();
            mhp = rnd.Next(20, 50);
            mattack = rnd.Next(15, 50);
            mmana = rnd.Next(5, 20);
            mgold = rnd.Next(3, 40);
            bhp = rnd.Next(200, 350);
            battack = rnd.Next(50, 100);
            bmana = rnd.Next(15, 30);
            bgold = rnd.Next(100, 160);
        }

        public static void heal()
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
        public static void megaHeal()
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
        public static void boost()
        {
            if (mana >= 30)
            {
                hp += 10;
                attack += 30;
                mana -= 30;
                komunikat("Użyłeś Boosta (+10 hp   +30 dmg   -30 many)");
            }
            else
            {
                komunikat("Brak many");
            }
        }
        public static void superBoost()
        {
            if (mana >= 30)
            {
                hp += 100;
                attack += 1000;
                mana -= 400;
                komunikat("Użyłeś Super Sayanina (+100 hp   +1000 dmg   -400 many)");
            }
            else
            {
                komunikat("Brak many");
            }
        }


        public static void sklep()
        {
            Console.Clear();
            Console.WriteLine("\n *Widzisz ceny na tablic* ");
            Console.WriteLine("\n1 - heal (+25 hp) 5 złota \n 2 - lepsza broń (+20 ataku)  13 złota \n 3 - relaks w spa (+50 many) 8 złota \n dowolny inny numer - wyjdz");
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
                    komunikat("\nWychodzisz ze sklepu");
                    break;
            }
        }


        static void sklepRelaksSpa()
        {
            if (gold - 8 < 0)
            {
                komunikat($"\nnie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {8 - gold} złota");
            }
            else
            {
                gold -= 8;
                mana += 50;
            }
        }

        static void sklepBron()
        {
            if ((gold - 15) < 0)
            {
                komunikat($"\nnie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {15 - gold} złota");
            }
            else
            {
                gold -= 15;
                attack += 20;
            }
        }

        static void sklepHeal()
        {
            if ((gold - 5) < 0)
            {
                komunikat($"\nnie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {5 - gold} złota");
            }
            else
            {
                gold -= 5;
                hp += 25;
            }
        }

        static void Main()
        {
            int round = 0;
            wyborPostac();
            while (hp > 0)
            {

                Console.Clear();
                Console.WriteLine($"\n{name}:\n hp - {hp}\n dmg - {attack}\n mana - {mana}\n złoto - {gold}");
                Console.WriteLine("\n===============\n");
                Console.WriteLine("\nCo chcesz zrobić? \n 1 - Idz do sklepu\n 2 - Idz na wyprawe");
                int inp = getIntFromConsole();
                if (inp == 1)
                {
                    sklep();
                }
                else if (inp == 2)
                {
                    Console.Clear();
                    generowanieStatowPotwora();

                    Random rnn = new Random();

                    int r = rnn.Next(8, 16);
                    if (round == r)
                    {
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
            Console.Clear();
            int runda = 1;
            Console.WriteLine("Walka");
            while (mhp > 0)
            {

                komunikat($"\nPotwór zadaje ci {mattack}");
                hp -= mattack;
                komunikat($"\nTy zadajesz mu {attack}");
                mhp -= attack;

                if (hp <= 0)
                {
                    komunikat("UMARŁEŚ!!!!");
                    return;
                }

                runda += 1;
            }
            komunikat($"\nzabierasz potworowi {mgold} złota i pobierasz kawałki many z jego duszy");
            gold += mgold;
            mana += mmana;
        }

        static int normalZaklecia()
        {
            int x;
            komunikat("\nZaklęcia\n 1 - heal(+15   hp   -20 many)\n 2 - Mega Heal(+90   hp   -100 many)\n 3 - Boost(+10 hp   +30 dmg   -30 many)");
            x = getIntFromConsole();
            if (x == 1)
            {
                heal();
            }
            if (x == 2)
            {
                megaHeal();
            }
            if (x == 3)
            {
                boost();
            }
            else
            {
                komunikat("\nzły numer");
            }

            return x;
        }

        static void normalUcieczka()
        {
            komunikat("\nUciekasz");
            Random rnd = new Random();
            int ucieczka = rnd.Next(1, 6);
            if (ucieczka == 2 || ucieczka == 5)
            {
                komunikat("\nUdaje ci się uciec");
            }
            else
            {
                hp -= (mattack * 2);
                komunikat("\nNie udaje ci się uciec potwór zadaje ci podwójne obrażenia");
            }
        }

        static void normalSpotkanie()
        {
            Console.WriteLine("\n Spotykasz potwora\nCo robisz?\n 1 - Walczysz\n 2 - Używasz Zaklęć\n 3 - spróbuj ucieczki");
            Console.WriteLine($"\n Potwór: hp - {mhp}\n dmg - {mattack}\n mana - {mmana}\n złoto - {mgold}");
            int input = getIntFromConsole();
            int x = 0;
            if (input == 1)
            {
                normalwalka();
            }
            if (input == 2)
            {
                x = normalZaklecia();
            }
            if (input == 3)
            {
                normalUcieczka();
            }
        }
        private static void bossSpotkanie()
        {
            komunikat($"\n SPOTYKASZ BOSA!!!!\n Jego staty to :\n hp - {bhp} \n dmg - {battack} \n mana - {bmana} \n gold - {bgold}\n\n TYM RAZEM NIE UCIEKNIESZ!!!\n 1 - Walczysz!!\n 2 - Używasz Zaklęć");

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

                komunikat($"\nBoss zadaje ci {battack}");
                hp -= mattack;
                komunikat($"\nTy zadajesz mu {attack}");
                mhp -= attack;

                if (hp <= 0)
                {
                    throw new Exception("Umarłeś");


                }
                komunikat($"\nzabierasz Bossowi {bgold} złota i pobierasz kawałki manny z jego duszy");
                gold += bgold;
                mana += bmana;
                runda += 1;


            }
        }

        private static void bossZaklecia()
        {
            int z = 0;
            komunikat("\nZaklęcia\n 1 - heal(+15   hp   -20 many)\n 2 - Mega Heal(+90   hp   -100 many)\n Boost(+10 hp   +30 dmg   -30 many)\n Super Sayanin(+100 hp   +1000 dmg   -400 many)");
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
                komunikat("\nzły numer");
            }
        }
    }
}