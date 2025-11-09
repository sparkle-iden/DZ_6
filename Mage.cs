using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Mage : Character
    {
        public Spell[] Spelist = new Spell[]
        {
            new Fireball(),
            new HealUp(),
            new Shield()
        };

        public Mage(string name) : base(name, 8000, 0)
        {

        }

        public void CastSpell(int spellIndex, Character target)
        {
            if (spellIndex >= 0 && spellIndex < Spelist.Length && Spelist[spellIndex].CurrentCooldown == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 4);
                Console.WriteLine($"{Name} использует {Spelist[spellIndex].Name}!");
                Spelist[spellIndex].Cast(target);
            }
            else
            {
                Console.WriteLine("Заклинание не готово или неверный индекс!");
            }
        }

        public void ShowSpells()
        {
            Console.WriteLine("\nДоступные заклинания:");
            for (int i = 0; i < Spelist.Length; i++)
            {
                if (Spelist[i].CanCast())
                    Console.WriteLine($"{i + 1}. {Spelist[i].Name} - {Spelist[i].Description} (Готово)");
                else
                    Console.WriteLine($"{i + 1}. {Spelist[i].Name} - {Spelist[i].Description}");
            }
        }
    }
}