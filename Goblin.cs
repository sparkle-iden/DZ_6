using System;

namespace Dz_5
{
    internal class Goblin : Character
    {
        public Goblin(string name) : base( name, 100, 1, 100) 
        {
        }

        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);
        }

        public int Attack()
        {
            Random random = new Random();
            int damage = random.Next(1, 10);
            Console.WriteLine("Урон гоблина: " + damage);
            return damage;
        }
        
    }
}
