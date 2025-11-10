using System;

namespace Dz_5.Effects
{
    class Burning : Effect
    {
        public Burning(Character target) : base("Горение", 10)
        {
            Start(target);
        }

        public override void Start(Character target)
        {
            Console.WriteLine($"{target.Name} горит!");
            BattelTime.TotalCast.Add(this);
        }

        public override void EachTurn(Character target)
        {
            target.ApplyDamage(3);
            BattelTime.TotalDamage += 3;
            Console.WriteLine($"{target.Name} получает 3 урона от огня");
            Turns--;
        }

        public override void EndEffect()
        {
            Console.WriteLine("Потух");
        }
    }
}
