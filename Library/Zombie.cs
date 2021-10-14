using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Zombie : Enemy
    {
        public bool HasRedEyes { get; set; }

        public Zombie(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, string description, bool hasRedEyes) : base
            (name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HasRedEyes = hasRedEyes;
        }//END FQCTOR

        public Zombie()
        {
            MaxLife = 10;
            MaxDamage = 3;
            Name = "A Bloody Zombie";
            Life = 100;
            HitChance = 20;
            Block = 10;
            MinDamage = 1;
            Description = "It's a slow moving zombie. It looks like it already had a few meals.";
            HasRedEyes = false;
        }//END DEFAULT ZOMBIE CTOR

        public override string ToString()
        {
            return base.ToString() + (HasRedEyes ? "This zombie has red eyes." : "The zombie's eyes look normal.");
        }//END TOSTRING

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (HasRedEyes)
            {
                calculatedBlock += calculatedBlock / 2;
            }//END IF

            return calculatedBlock;
        }//END CALCBLOCK
    }//END CLASS
}// END NAMESPACE
