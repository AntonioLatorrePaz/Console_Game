using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    public abstract class Item
    {
        protected string name;
        protected string description;
        protected char input;
        protected int value;
        

        public Item(int _value)
        {
            value = _value;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public char Input
        {
            get
            {
                return input;
            }
        }
        public int Value
        {
            get
            {
                return value;
            }
        }

        public virtual void Use(Character character)
        {

        }

    }
}
