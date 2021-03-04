using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    abstract class Bomb : Item
    {
        protected int bombDamage;

        protected Bomb(int _value) : base(_value)
        {

        }

        public int BombDamage
        {
            get
            {
                return bombDamage;
            }
        }


    }

}

