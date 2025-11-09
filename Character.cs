using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal abstract class Character
    {
        protected string name;
        protected int health;
        protected bool IsDead = false;
        protected int armor;

        private Effect[] CastList = new Effect[3];

        public void AddEffect(Effect effect)
        { 
            int freeSlot = -1;
            for (int i = 0; i < 3; i++)
            {

                if (CastList[i] == null)
                {
                    freeSlot = i;
                    break;
                }
            }
            if (freeSlot == -1)
            {
                Console.WriteLine("Нет свободных слотов для эффекта!");
            }
            if (freeSlot != -1)
            {
                CastList[freeSlot] = effect;
                effect.Start(this);
            }
        }
        public void UpdateEffect()
        {
            for (int i = 0; i < CastList.Length; i++)
            {
                if (CastList[i] != null&& CastList[i].Turns != 0 )
                {
                    CastList[i].EachTurn(this);

                    Console.WriteLine($"Эффект {CastList[i].Name} действует еще {CastList[i].Turns} ходов");
                    if(CastList[i].Turns == 0)
                    {
                        CastList[i].EndEffect();
                        CastList[i] = null;
                    }
                }
               
            }
        }


        public string Name
        {
            get { return name; }
        }
        public int Health
        {
            get { return health; }
        }

        public bool IsDEAD
        {
            get { return IsDead; }
        }

        public int Armor
        {
            get { return armor; }
        }

        public Character(string Name, int Health, int Armor)
        {
            name = Name;
            health = Health;
            armor = Armor;
        }


        public virtual void ApplyDamage(int damage)
        {
            if (!IsDead)
            {
                int actualDamage = damage - armor;
                if (actualDamage < 0)
                {
                    actualDamage = 0;
                }

                health -= actualDamage;
                Console.WriteLine($"Персонаж {name} получил {actualDamage} урона (броня поглотила {armor})! Здоровье: {health}");

                if (health <= 0)
                {
                    IsDead = true;
                    Console.WriteLine($"Персонаж {name} умер!(");
                }
            }
        }




        public void Heal(int heal)
        {
            int heals = 15;
            if (!IsDead)
            {
                health += heals;
            }
        }
    }
}