﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Forest : DangerZone
    {

        
        public Forest()
        {
            name = "Dark Forest";
            localLevel = 1;
            description = "Enimies in this location are undead, and will come back to life if you don't have a Pendant equiped";
            input = 'F';

        }
       

    }
}
