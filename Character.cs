using System;
using Dz_5.Effects;

namespace Dz_5
{
    internal abstract class Character
    {
        protected string name;
        protected int HealUp;
        protected int HealMax;
        protected int Energy;
        protected int EnergyMax;
        protected int Gold;
        protected bool IsDead = false;
        protected int armor;
        protected int TempArmor;

        private Effect[] CastList = new Effect[3];

      
        protected Weapon EquippedWeapon;
        protected Armor EquippedArmor;
        protected Item EquippedRing;

       
        public Inventory Inventory { get; private set; }

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
            get { return armor + TempArmor + (EquippedArmor != null ? EquippedArmor.ArmorValue : 0); }
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

            
            EnergyMax = 100;
            Energy = EnergyMax;
            Gold = 0;

            Inventory = new Inventory(20);
        }

     
        public void AddHealth(int value)
        {
            if (IsDead) return;
            int old = HealUp;
            HealUp = Math.Max(0, Math.Min(HealMax, HealUp + value));
            int actual = HealUp - old;
            if (actual > 0)
            {
                BattelTime.TotalHeal += actual;
            }
            if (HealUp <= 0)
            {
                IsDead = true;
                Console.WriteLine($"Персонаж {name} умер! (");
            }
        }

        public void AddEnergy(int value)
        {
            Energy = Math.Max(0, Math.Min(EnergyMax, Energy + value));
        }

        public void AddGold(int value)
        {
            if (value < 0)
            {
            
                Gold = Math.Max(0, Gold + value);
            }
            else
            {
                Gold += value;
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapon == null) return;
            if (EquippedWeapon != null)
            {
               
                Inventory.Add(EquippedWeapon);
            }
            EquippedWeapon = weapon;
            Console.WriteLine($"{name} экипировал оружие: {weapon.Name}");
        }

        public void EquipArmor(Armor arm)
        {
            if (arm == null) return;
            if (EquippedArmor != null)
            {
                Inventory.Add(EquippedArmor);
            }
            EquippedArmor = arm;
            Console.WriteLine($"{name} экипировал броню: {arm.Name}");
        }

        public void EquipRing(Item ring)
        {
            if (ring == null) return;
            if (EquippedRing != null)
            {
                Inventory.Add(EquippedRing);
            }
            EquippedRing = ring;
            Console.WriteLine($"{name} надел кольцо: {ring.Name}");
        }

        public void UnequipWeapon()
        {
            if (EquippedWeapon != null)
            {
                Inventory.Add(EquippedWeapon);
                Console.WriteLine($"{name} снял оружие: {EquippedWeapon.Name}");
                EquippedWeapon = null;
            }
            else Console.WriteLine("Оборудованного оружия нет");
        }

        public void UnequipArmor()
        {
            if (EquippedArmor != null)
            {
                Inventory.Add(EquippedArmor);
                Console.WriteLine($"{name} снял броню: {EquippedArmor.Name}");
                EquippedArmor = null;
            }
            else Console.WriteLine("Надетой брони нет");
        }

        public void UnequipRing()
        {
            if (EquippedRing != null)
            {
                Inventory.Add(EquippedRing);
                Console.WriteLine($"{name} снял кольцо: {EquippedRing.Name}");
                EquippedRing = null;
            }
            else Console.WriteLine("Кольца нет");
        }


        public virtual void ApplyDamage(int damage)
        {
            if (!IsDead)
            {
                int remainingDamage = damage;
                if (TempArmor > 0 && remainingDamage > 0)
                {
                    int absorbedByTempArmor = Math.Min(TempArmor, remainingDamage);
                    TempArmor -= absorbedByTempArmor;
                    remainingDamage -= absorbedByTempArmor;
                    Console.WriteLine($"Персонаж {name} временная броня поглотила {absorbedByTempArmor} урона. Осталось временной брони: {TempArmor}");
                }
                if (remainingDamage > 0)
                {
                    int totalArmor = armor + (EquippedArmor != null ? EquippedArmor.ArmorValue : 0);
                    int actualDamage = remainingDamage - totalArmor;
                    if (actualDamage < 0)
                    {
                        actualDamage = 0;
                    }
                    HealUp -= actualDamage;
                    Console.WriteLine($"Персонаж {name} получил {actualDamage} урона (броня поглотила {totalArmor})! Здоровье: {HealUp}");

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
          
            AddHealth(15);
            Console.WriteLine($"{name} восстановил 15 здоровья");
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

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Здоровье: {HealUp}/{HealMax}");
            Console.WriteLine($"Энергия: {Energy}/{EnergyMax}");
            Console.WriteLine($"Золото: {Gold}");
            Console.WriteLine($"Оружие: {(EquippedWeapon != null ? EquippedWeapon.Name : "Нет")}");
            Console.WriteLine($"Броня: {(EquippedArmor != null ? EquippedArmor.Name : "Нет")}");
            Console.WriteLine($"Кольцо: {(EquippedRing != null ? EquippedRing.Name : "Нет")}");
        }
    }
}