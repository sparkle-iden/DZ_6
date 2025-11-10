using System;
using Dz_5.Effects;
namespace Dz_5
{
    class Fireball : Spell
    {
        public Fireball()
        {
            Name = "Огненный шар";
            Description = "Наносит урон и может поджечь";
            Cooldown = 5;
        }

        public override void Cast(Character target)
        {
            
            StartCooldown();

            Random random = new Random();
            if (random.Next(1, 1) == 1)
            {
                target.AddEffect(new Burning(target));
                target.ApplyDamage(50);
                BattelTime.TotalDamage += 50;
            }
            else
            {
                target.ApplyDamage(25);
                BattelTime.TotalDamage += 25;
            }
        }
    }
}
