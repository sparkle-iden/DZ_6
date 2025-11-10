using System;
using Dz_5.Effects;
namespace Dz_5
{
    internal abstract class Character
    {
        protected string name;
        protected int HealUp;
        protected int HealMax;
        protected bool IsDead = false;
        protected int armor;
        protected int TempArmor;

        private Effect[] CastList = new Effect[3];

        public string Name
        {
            get { return name; }
        }
        public int Health
        {
            get { return HealUp; }
        }

        public bool IsDEAD
        {
            get { return IsDead; }
        }

        public int Armor
        {
            get { return armor; }
        }
        public int tempArmor
        {
            get { return TempArmor; }
            set { TempArmor = value; }
        }

        public Character(string Name, int Health, int Armor, int healMax)
        {
            name = Name;
            HealUp = Health;
            armor = Armor;
            HealMax = healMax;

        }


        public virtual void ApplyDamage(int damage)
        {
            if (!IsDead)
            {
                int remainingDamage= damage;
                if (TempArmor > 0&&remainingDamage>0)
                {
                   int absorbedByTempArmor = Math.Min(TempArmor, remainingDamage);
                   TempArmor -= absorbedByTempArmor;
                   remainingDamage -= absorbedByTempArmor;
                    Console.WriteLine($"Персонаж {name} временная броня поглотила {absorbedByTempArmor} урона. Осталось временной брони: {TempArmor}");

                }
                if (remainingDamage > 0)
                {
                    int actualDamage = remainingDamage - armor;
                    if (actualDamage < 0)
                    {
                        actualDamage = 0;
                    }
                    HealUp -= actualDamage;
                    Console.WriteLine($"Персонаж {name} получил {actualDamage} урона (броня поглотила {armor})! Здоровье: {HealUp}");

                    if (HealUp <= 0)
                    {
                        IsDead = true;
                        Console.WriteLine($"Персонаж {name} умер!(");
                    }
                }
            }
        }

        public void Healing()
        {
            int heals = 15;
            BattelTime.TotalHeal += heals;
            if (!IsDead)
            {
                HealUp += heals;
            }
        }

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

            }
        }
        public void UpdateEffect()
        {
            for (int i = 0; i < CastList.Length; i++)
            {
                if (CastList[i] != null && CastList[i].Turns != 0)
                {
                    CastList[i].EachTurn(this);

                    if (CastList[i].Turns == 0)
                    {
                        CastList[i].EndEffect();
                        
                        
                        CastList[i] = null;
                    }
                    else
                    {
                        Console.WriteLine($"Эффект {CastList[i].Name} действует еще {CastList[i].Turns} ходов");
                    }
                }

            }
        }
    }
}