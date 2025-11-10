using System;
using Dz_5.Effects;

namespace Dz_5
{
    internal class Shield : Spell
    {
        public Shield()
        {
            Name = "Щит";
            Description = "Защищает от урона";
            Cooldown = 3;
        }

        public override void Cast(Character target)
        {
            Console.WriteLine("Магический щит!");
            target.AddEffect(new Shielded(target));
            StartCooldown();
        }
    }
}
