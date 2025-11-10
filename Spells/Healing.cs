using System;


namespace Dz_5
{
    internal class Healing : Spell
    {
        public Healing()
        {
            Name = "Лечение";
            Description = "Восстанавливает здоровье";
            Cooldown = 4;
        }

        public override void Cast(Character target)
        {

            Console.WriteLine("Исцеление!");
            target.Healing();
            Console.WriteLine($"{target.Name} восстановил 15 здоровья");
            StartCooldown();
        }
    }
}
