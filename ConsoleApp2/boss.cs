using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Boss : Potwor
    {
        public Boss(int poziom) : base(poziom)
        {
            hp = hp * 4 + 50;
            atak = atak * 3;
            mana = mana * 3 + 100;
            gold = gold * 3;
            name = "BOSS " + name;
        }


    }
}
