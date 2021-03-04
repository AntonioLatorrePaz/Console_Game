using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    class FragBomb:Bomb
    {
        public FragBomb(int _value) : base(_value)
        {
            name = "Frag Bomb";
            description = "Deals damage on enemies";
            bombDamage = 30;
            input = 'B';
            value = 4;
        }
        public override void Use(Character character)
        {
            character.TakeDamage(BombDamage);
        }
    }
}
