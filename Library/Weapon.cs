using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Weapon
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int CriticalHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//END IF
                else
                {
                    _minDamage = 1;
                }//END ELSE
            }//END SET
        }//END MinDamage()

        public Weapon(int minDamage, int maxDamage, string name, int criticalHitChance, bool isTwoHanded)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            CriticalHitChance = criticalHitChance;
            IsTwoHanded = isTwoHanded;
        }//END FQCTOR

        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage \n" +
                "Critical Hit: {3}%\t{4}",
                Name, MinDamage, MaxDamage, CriticalHitChance,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }//END ToString()
    }//END CLASS
}//END NAMESPACE
