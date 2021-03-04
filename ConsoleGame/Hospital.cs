using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Hospital : Location
    {
        char healInput = 'A';

        public char HealInput
        {
            get => healInput;
        }

        public Hospital()
        {
            name = "Hospital";
            description = "Here you can heal yourself";
            input = 'H';
            payValue = 2;

        }

        public void Heal(Player player)
        {
            player.RecoverLife(player.MaxLife);
        }
        
    }
}
