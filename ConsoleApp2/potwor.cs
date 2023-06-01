using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Potwor : Postac
    {
        public Potwor(int poziom)
        {
            Random rnd = new Random();
            switch (poziom)
            {
                case 1:
                    hp = rnd.Next(20, 50);
                    atak = rnd.Next(15, 50);
                    mana = rnd.Next(5, 20);
                    gold = rnd.Next(3, 40);
                    break;
                case 2:
                    hp = rnd.Next(40, 70);
                    atak = rnd.Next(20, 55);
                    mana = rnd.Next(10, 30);
                    gold = rnd.Next(3, 40);
                    break;
                case 3:
                    hp = rnd.Next(60, 100);
                    atak = rnd.Next(40, 65);
                    mana = rnd.Next(20, 50);
                    gold = rnd.Next(12, 45);
                    break;
                case 4:
                    hp = rnd.Next(100, 180);
                    atak = rnd.Next(50, 70);
                    mana = rnd.Next(30, 50);
                    gold = rnd.Next(20, 50);
                    break;
            }
            if (hp <= 30)
            {
                name = "SZKIELET";
            }
            else if (hp > 30 && hp <= 80)
            {
                name = "ZOMBIE";
            }
            else if (hp > 80 && hp <= 150)
            {
                name = "MINOTAUR";
            }
            else if (hp > 150 && hp <= 180)
            {
                name = "SMOK";
            }
        }
        public void staty()
        {
            Console.WriteLine("◄►─────────────POTWÓR────────────◄►");
            base.staty();
        }
    }
}
