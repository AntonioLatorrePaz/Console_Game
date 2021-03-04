using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    class LifePotion:Potion
    {
        public LifePotion(int _value):base(_value)
        {
            name = "Life Potion";
            description = "Regenera a sua vida";
            lifeRegen = 30;
            input = 'P';
            value = 3;
        }
        public override void Use(Character character)
        {
            character.RecoverLife(lifeRegen);
        }
    }
}
