using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Goblin : Character
    {
        public Goblin() : base("Григорий", 5000, 1) 
        {
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
