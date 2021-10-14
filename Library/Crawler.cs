using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Crawler : Enemy
    {
        public Crawler()
        {
            MaxLife = 12;
            MaxDamage = 10;
            Life = 100;
            MinDamage = 8;
            HitChance = 35;
            Block = 75;
            Name = "Crawler";
            Description = "A mutation of a zombie that crawls on its hands and feet. Don't let your guard down though - these Crawlers move extremely quickly.";
        }//END DEFAULT
    }//END CLASS
}//END NAMESPACE
