using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson5
{
    abstract class Effect
    {
        public string Name;
        public int Turns;

        public Effect(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }

        public abstract void Start(Character target);
        public abstract void EachTurn(Character target);
        public abstract void EndEffect();
    }

    class Burning : Effect
    {
        public Burning(Character target) : base("Горение", 10)
        {
            Start(target);
        }

        public override void Start(Character target)
        {
            Console.WriteLine($"{target.Name} горит!");
        }

        public override void EachTurn(Character target)
        {
            target.ApplyDamage(3);
            Console.WriteLine($"{target.Name} получает 3 урона от огня");
            Turns--;
        }

        public override void EndEffect()
        {
            Console.WriteLine("Потух");
        }
    }

    class Shielded : Effect
    {
        private int originalArmor;
        public Shielded() : base("Щит", 3) { }

        public override void Start(Character target)
        {
            Console.WriteLine($"{target.Name} защищен! Броня увеличена.");
        }

        public override void EachTurn(Character target)
        {
            
            Console.WriteLine($"{target.Name} под защитой щита. Осталось ходов: {Turns}");
            Turns--; 
        }
        public override void EndEffect()
        {
            Console.WriteLine("Эффект щита кончился");
            
        }
    }
}
