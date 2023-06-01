using ConsoleApp2;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace gra
{
    class Gra : Konsola
    {


         int poziom = 0;
         Gracz gracz;
         Potwor potwor;

        
          


        public void poziomTrudnosci()
        {
            Console.WriteLine("\n◄►───────────WYBIERZ─POZIOM─TRUDNOŚCI─────────────◄►");
            Console.WriteLine("        1 ────► Łatwy");
            Console.WriteLine("        2 ────► Średni");
            Console.WriteLine("        3 ────► Trudny");
            Console.WriteLine("        4 ────► Impossible");
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


        public Gracz wyborPostac()
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
                    return new Gracz(x);
                }
            }
            return null;
        }



        

        static void Main()
        {
            Gra gra = new Gra();
            gra.graj();

        }

        private int graj()
        {
            int round = 0;
            poziomTrudnosci();

            gracz = wyborPostac();
            Sklep sklep = new Sklep(gracz);

            while (gracz.hp > 0)
            {
                Console.Clear();
                gracz.staty();
                Console.WriteLine("\n◄►────────────────CO─CHCESZ─ZROBIĆ────────────────◄►");
                Console.WriteLine("    1 ────► Idz do sklepu");
                Console.WriteLine("    2 ────► Idz na wyprawe");
                Console.WriteLine("◄►────────────────────────────────────────────────◄►");

                int inp = getIntFromConsole();
                if (inp == 1)
                {
                    Console.Clear();
                    gracz.staty();
                    sklep.sklep();
                }
                else if (inp == 2)
                {
                    potwor = new Potwor(poziom);

                    Random rnn = new Random();
                    
                    if (round == rnn.Next(8, 16))
                    {
                        potwor = new Boss(poziom);
                        round = 0;
                    }

                    round += 1;
                    Console.Clear();
                    gracz.staty();
                    potwor.staty();
                    spotkanie();
                }
            }

            return round;
        }
         void spotkanie()
        {
            bool isBoss = potwor is Boss;

            while (potwor.hp > 0)
            {
                Console.Clear();
                gracz.staty();
                potwor.staty();
                Console.WriteLine("\n◄►────────────────SPOTYKASZ─POTWORA────────────────◄►");
                Console.WriteLine("    1 ────► Walczysz");
                Console.WriteLine("    2 ────► Używasz Zaklęć");
                if (!isBoss)
                Console.WriteLine("    3 ────► Spróbuj ucieczki");
                Console.WriteLine("◄►────────────────────────────────────────────────◄►");

                int input = getIntFromConsole();
                if (input == 1)
                {
                    Console.Clear();
                    gracz.staty();
                    potwor.staty();
                    gracz.walka(potwor);
                }
                if (input == 2)
                {
                    Console.Clear();
                    gracz.staty();
                    potwor.staty();
                    gracz.zaklecia(isBoss);
                }
                if (!isBoss && input == 3)
                {
                    int x = gracz.ucieczka(potwor);
                    if (x == 1)
                    potwor.hp = 0;
                }
            }
        }
    }
}