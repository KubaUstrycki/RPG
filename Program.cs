using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace gra
{
    class gra
    {

        static int[,] postacie = { { 200, 60, 0, 15 }, { 150, 30, 150, 20 }, { 120, 40, 30, 35 }, { 9999999, 9999999, 9999999, 9999999 } };
        static String[] nazwyPostaci = { "Wojownik", "Mag", "Bandyta", "BÓG" };
        static int poziom = 0;
        static int hp, attack, mana, gold = 0;
        static int mhp, mattack, mmana, mgold = 0;
        static String name = "";
        static String mname = "";

        static void komunikat(string x)
        {
            staty();
            Console.WriteLine("\n◄►─────────────────────────────────────────────────────────────────────◄►");
            Console.WriteLine($"{x}  ");
            Console.WriteLine("◄►─────────────────────────────────────────────────────────────────────◄►");
            Console.ReadKey();
            Console.Clear();
            staty();
        }
        static void staty()
        {
            if (name == "") 
                return;
            Console.Clear();
            Console.WriteLine("◄►───────────────────────────────◄►");
            Console.WriteLine($"    KLASA    ────► {name}");
            Console.WriteLine($"    HP       ────► {hp} ");
            Console.WriteLine($"    ATTACK   ────► {attack} ");
            Console.WriteLine($"    MANA     ────► {mana} ");
            Console.WriteLine($"    GOLD     ────► {gold} ");
            Console.WriteLine("◄►───────────────────────────────◄►");
            if (mhp > 0)
            {
                Console.WriteLine("◄►───────────────────────────────◄►");
                Console.WriteLine($"    NAZWA    ────► {mname} ");
                Console.WriteLine($"    HP       ────► {mhp} ");
                Console.WriteLine($"    ATTACK   ────► {mattack} ");
                Console.WriteLine($"    MANA     ────► {mmana} ");
                Console.WriteLine($"    GOLD     ────► {mgold} ");
                Console.WriteLine("◄►───────────────────────────────◄►");
            }

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

        public static void poziomTrudnosci()
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


        public static void wyborPostac()
        {
            hp = 0;

            Console.WriteLine("\n◄►─────────────────WYBIERZ─POSTAĆ─────────────────◄►");
            Console.WriteLine("        1 ────► Wojownik");
            Console.WriteLine("        2 ────► Mag");
            Console.WriteLine("        3 ────► Bandyta");
            Console.WriteLine("◄►──────────────────────────────────────────────────◄►");
            while (hp == 0)
            {
                int input = getIntFromConsole();
                if (input != 1 && input != 2 && input != 3 && input != 4)
                {
                    Console.WriteLine("zły numer");
                    
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
            staty();
        }

        public static void generowanieStatowPotwora()
        {
            Random rnd = new Random();
            switch (poziom)
            {
                case 1:
                    mhp = rnd.Next(20, 50);
                    mattack = rnd.Next(15, 50);
                    mmana = rnd.Next(5, 20);
                    mgold = rnd.Next(3, 40);
                    break;
                case 2:
                    mhp = rnd.Next(40, 70);
                    mattack = rnd.Next(20, 55);
                    mmana = rnd.Next(10, 30);
                    mgold = rnd.Next(3, 40);
                    break;
                case 3:
                    mhp = rnd.Next(60, 100);
                    mattack = rnd.Next(40, 65);
                    mmana = rnd.Next(20, 50);
                    mgold = rnd.Next(12, 45);
                    break;
                case 4:
                    mhp = rnd.Next(60, 100);
                    mattack = rnd.Next(50, 70);
                    mmana = rnd.Next(30, 50);
                    mgold = rnd.Next(20, 50);

                    break;
            }
            danePotwora();
        }
        public static void danePotwora()
        {
            if (mhp <= 30)
            {
                mname = "SZCZĄTKI";
            }
            else if (mhp > 30 && mhp <= 80)
            {
                mname = "SZKIELET";
            }
            else if (mhp > 80 && mhp <= 100)
            {
                mname = "ZOMBIE";
            }
            else if (mhp > 100 && mhp <= 130)
            {
                mname = "MINOTAUR";
            }
            else if (mhp > 120 && mhp <= 180)
            {
                mname = "SMOK";
            }
            else if (mhp > 180)
            {
                mname = "ŻNIWIARZ";
            }
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
            staty();
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


        static void sklepRelaksSpa()
        {
            const int CENA_SPA = 8;
            if (gold - CENA_SPA < 0)
            {
                komunikat($"Nie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {CENA_SPA - gold} złota");
            }
            else
            {
                gold -= CENA_SPA;
                mana += 50;
            }
        }

        static void sklepBron()
        {
            const int CENA_BRON = 15;
            if ((gold - CENA_BRON) < 0)
            {
                komunikat($"Nie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {CENA_BRON - gold} złota");
            }
            else
            {
                gold -= CENA_BRON;
                attack += 20;
            }
        }

        static void sklepHeal()
        {
            const int CENA_HEAL = 5;
            if ((gold - CENA_HEAL) < 0)
            {
                komunikat($"Nie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {CENA_HEAL - gold} złota");
            }
            else
            {
                gold -= CENA_HEAL;
                hp += 25;
            }
        }

        static void Main()
        {
            int round = 0;
            poziomTrudnosci();
            wyborPostac();
            while (hp > 0)
            {
                staty();
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
                    generowanieStatowPotwora();
                    staty();

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
            staty();
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
            staty();
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
            staty();
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