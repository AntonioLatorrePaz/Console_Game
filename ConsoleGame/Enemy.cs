using System;
using System.Collections.Generic;
using System.Text;

namespace Player_e_Inimigo_2
{
    class Enemy : Character
    {
        private int xpValue;
        private int coinValue;
        public int XpValue { get => xpValue; }

        public Enemy(int _level)
        {
            maxLife = 100 * _level;
            currentLife = maxLife;
            damage = 6 * _level;
            currentState = State.Alive;
            level = _level;
            xpValue = 10 * _level;
            Random random = new Random();
            int minValue = Math.Clamp(_level - 3,1,int.MaxValue);
            coinValue = 2 * random.Next(minValue, _level + 3);

        }
        public int CoinValue
        {
            get
            {
                return coinValue;
            }
        }

        protected override void Die()
        {
           
            base.Die();
            Console.WriteLine("The enemy died");
        }

    }
}
