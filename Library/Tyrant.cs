using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Tyrant : Enemy
    {
        public Tyrant()
        {
            MaxLife = 100;
            MaxDamage = 25;
            Life = 100;
            MinDamage = 8;
            HitChance = 55;
            Block = 15;
            Name = "G-1 Tyrant";
            Description = "After years of genetic research, the ultimate weapon was created. Neither a zombie nor a machine, a Tyrant is an unstoppable monster created from a human subject. Unfortunately, any shred of humanity is long gone from this grotesque being.";
        }//END DEFAULT
    }//END CLASS
}//END NAMESPACE
