using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
   public abstract class Character
    {
        public enum State
        {
            Alive,
            Dead
        }
        protected int level = 0;
        protected double maxLife;
        protected int damage;
        protected double currentLife;
        protected State currentState;

        public virtual int GetDamage()
        {
            return damage;
        }

        public virtual double GetCurrentLife()
        {
            return currentLife;
        }

        public virtual State GetState()
        {
            return currentState;
        }

        public virtual void Attack(Character character)
        {            
            character.TakeDamage(GetDamage());
        }

        public void TakeDamage(double damage)
        {
            currentLife = currentLife - damage;

            if (currentLife <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            currentState = State.Dead;
        }

        public string ShowLifeBar()
        {
            string lifeBar = "[";
            for (int i = 0; i < maxLife; i++)
            {
                if (currentLife >= i)
                    lifeBar += "■|";
                else
                lifeBar += " |";
            }
            lifeBar += "]";
            return(lifeBar);
        }

        public double MaxLife
        {
            get
            {
                return maxLife;
            }
        }
        public double RecoverLife(double life)
        {
            return currentLife = life;
        }

      //  public int UseItem(Item item)
      //  {
      //      return item.stats;
      //  }

    }
}
