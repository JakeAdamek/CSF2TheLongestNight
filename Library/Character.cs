using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }//END IF
                else
                {
                    _life = MaxLife;
                }//END ELSE
            }//END SET
        }//END INT LIFE

        public virtual int CalcBlock()
        {
            return Block;
        }//END CalcBlock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//END CalcHitChance()

        public virtual int CalcDamage()
        {
            return 0;
        }//END CalcDamage()

    }//END CLASS
}//END NAMESPACE
