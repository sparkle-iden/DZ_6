using Lesson5;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Runtime.InteropServices;

namespace Lesson5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите имя мага:");

            Mage mage = new Mage(Console.ReadLine());
            Goblin goblin = new Goblin();

            Console.WriteLine("Бой начинается!");

            while (!mage.IsDEAD && !goblin.IsDEAD)
            {
                
                Console.WriteLine($"\nХод {mage.Name} " + $"Здоровье: {mage.Health} ");
                mage.ShowSpells(); 

                Console.WriteLine("Выберите заклинание (1-3):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int spellChoice) && spellChoice >= 1 && spellChoice <= 3)
                {
                    mage.CastSpell(spellChoice - 1, goblin);
                }
                else
                {
                    Console.WriteLine("Неверный выбор! Пропуск хода.");
                }

                goblin.UpdateEffect();

                if (goblin.IsDEAD || mage.IsDEAD)
                {
                    break;
                }

                Console.WriteLine($"\nХод {goblin.Name}" + $" Здоровье: {goblin.Health}");
                mage.ApplyDamage(goblin.Attack());
                mage.UpdateEffect();
                goblin.UpdateEffect();
            }

            Console.WriteLine(mage.IsDEAD ? "Гоблин победил!" : "Маг победил!");
            Console.ReadKey();
        }
    }
}
