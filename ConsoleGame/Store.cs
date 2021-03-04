using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Store : Location
    {
        LifePotion lifePotion = new LifePotion(3);
        Amuleto amuleto = new Amuleto(4);
        FragBomb fragBomb = new FragBomb(4);
        Item[] itens;

        public Store()
        { 

            itens = new Item[] { lifePotion, amuleto, fragBomb };
            name = "Store";
            description = "Lamp oil, rope, BOMBS. You want it? it's yours my friend, as long  as you have enough coins";
            input = 'S';
        }

        public Item[] Itens
        {
            get
            {
                return itens;
            }
        }

    }
}
