using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    abstract class Potion : Item
    {
        protected int lifeRegen;

        protected Potion(int _value):base(_value)
        {
            
        }

        public int LifeRegen
        {
            get
            {
                return lifeRegen;
            }
        }

        
    }
}
