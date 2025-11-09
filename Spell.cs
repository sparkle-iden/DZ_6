using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson5
{
    abstract class Spell
    {
        public string Name;
        public string Description;
        public int Cooldown;
        public int CurrentCooldown = 0;

        public bool CanCast()
        {
            return CurrentCooldown == 0;
        }

        public void StartCooldown()
        {
            CurrentCooldown = Cooldown;
        }

        public void UpdateCooldown()
        {
            if (CurrentCooldown > 0)
                CurrentCooldown--;
        }

        public abstract void Cast(Character target);
    }

    class Fireball : Spell
    {
        public Fireball()
        {
            Name = "Огненный шар";
            Description = "Наносит урон и может поджечь";
            Cooldown = 2;
        }

        public override void Cast(Character target)
        {
            Console.WriteLine("Огненный шар!");
            target.ApplyDamage(12);
            StartCooldown();

            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                target.AddEffect(new Burning(target));
               

            }
        }
    }

    class Shield : Spell
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
            target.AddEffect(new Shielded());
            StartCooldown();
        }
    }

    class HealUp : Spell
    {
        public HealUp()
        {
            Name = "Лечение";
            Description = "Восстанавливает здоровье";
            Cooldown = 4;
        }

        public override void Cast(Character target)
        {
            Console.WriteLine("Исцеление!");
            target.Heal(15);
            Console.WriteLine($"{target.Name} восстановил 15 здоровья");
            StartCooldown();
        }
    }
}