using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Amuleto : Item
    {
        public Amuleto(int _value) : base(_value)
        {
            name = "Amuleto";
            description = "Will protect you";
            input = 'A';
            value = 4;
        }

        public override void Use(Character character)
        {
            Console.WriteLine("Nothing happens");
        }
    }
}
