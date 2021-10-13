using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Enemy : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
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
        }//END MINDAMAGE

        public Enemy()
        {

        }

        public Enemy(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }//END FQCTOR

        public override string ToString()
        {
            return string.Format("***** Enemy *****\n" +
                "{0}\n" +
                "Life: {1} to {2}\n" +
                "Damage: {3} to {4}\n" +
                "Block: {5}\n" +
                "Description:\n{6}",
                Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }//END TOSTRING

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }//END CALCDAMAGE
    }//END CLASS
}//END NAMESPACE
