using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    class Location
    {
        protected string name;
        protected string description;
        protected char input;
        protected int payValue;
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
        public int PayValue
        {
            get
            {
                return payValue;
            }
        }





    }
}
