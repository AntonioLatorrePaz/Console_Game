using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Player : Character
    {

        private int experiencePoints = 0;
        private int coins;
        double maxExp = 100;
        public Inventario inventario = new Inventario();

        public int Level
        {
            get
            {
                return level;
            }
        }

        public int ExperiencePoints
        {
            get
            {
                return experiencePoints;
            }
        }

        public float Coins
        {
            get
            {
                return coins;
            }
        }

        public Player()
        {
            Initialize();
        }

        public Player(int initialLevel)
        {
            level = initialLevel;
            Initialize();

        }

        private void Initialize()
        {
            maxLife = 100;
            currentLife = maxLife;
            damage = 10;
            currentState = State.Alive;
        }


        public override int GetDamage()
        {
            damage = (int)(damage + (damage * Level * 0.23));

            return base.GetDamage();
        }

        public override void Attack(Character character)
        {
            base.Attack(character);
            if (character.GetState() == State.Dead)
            {
                if (character.GetType() == typeof(Enemy))
                {
                    Enemy inimigo = (Enemy)character;
                    XPGain(inimigo.XpValue);
                    CoinGain(inimigo.CoinValue);
                    Console.WriteLine($"O inimigo dropou {inimigo.CoinValue} coins");
                }
            }
        }

        private void XPGain(int XP)
        {
            experiencePoints = ExperiencePoints + XP;
            if (ExperiencePoints >= maxExp)
            {
                LevelUp();
            }
        }

        private void CoinGain(int _coins)
        {
            coins += _coins;
        }

        public int BuyItem(int _coins, Item item)
        {
            coins -= _coins;
            inventario.AdicionarItem(item);
            return coins;
        }

        public int UseHospital(int _coins)
        {
            coins -= _coins;
            return coins;
        }

        public void RemoveItem(Item item)
        {
            inventario.RemoverItem(item);
        }

        private void LevelUp()
        {
            level = Level + 1;
            maxLife = maxLife + (maxLife * 0.1);
            currentLife = maxLife;
            maxExp = maxExp + (maxExp * 0.75);
        }

    }
}
