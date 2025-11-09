using Lesson5;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Lesson5
{
    class Program
    {
        
        static void Main()
        {
            int cursorTop;
            int turnCounter = 1;
            Console.WriteLine("Введите имя мага:");

            Mage mage = new Mage(Console.ReadLine());
            Goblin goblin = new Goblin();

            Console.WriteLine("Бой начинается!");

            while (!mage.IsDEAD && !goblin.IsDEAD)
            {
                Console.WriteLine($"\n--- Ход {turnCounter} ---");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Здоровье: {mage.Name} {mage.Health} ");
                Console.WriteLine($"Здоровье: {goblin.Name} {goblin.Health} ");
                Console.SetCursorPosition(0, 4);
                Console.WriteLine($"\nХод {mage.Name} ");
                mage.ShowSpells(); 

                Console.WriteLine("Выберите заклинание (1-3):");
                string input = Console.ReadLine();
                int spellChoice;
                if (int.TryParse(input,  out spellChoice) && spellChoice >= 1 && spellChoice <= 3)
                {
                    mage.CastSpell(spellChoice - 1, goblin);
                }
                else
                {
                    Console.WriteLine("Неверный выбор! Пропуск хода.");
                }
                for(int i =0; i< mage.Spelist.Length; i++)
                {
                    if(mage.Spelist[i].CurrentCooldown > 0)
                    {
                        mage.Spelist[i].UpdateCooldown();
                    }
                }
                  
                goblin.UpdateEffect();

                if (goblin.IsDEAD || mage.IsDEAD)
                {
                    break;
                }
             
                Console.WriteLine($"\nХод {goblin.Name}");
                mage.ApplyDamage(goblin.Attack());
                mage.UpdateEffect();
                goblin.UpdateEffect();
                cursorTop = Console.CursorTop;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Здоровье: {mage.Name} {mage.Health} ");
                Console.WriteLine($"Здоровье: {goblin.Name} {goblin.Health} ");
                Console.SetCursorPosition(0,cursorTop);
                Console.WriteLine("Продолжить бой? (any/n)");
                if (Console.ReadLine() == "n")
                {
                    break;
                }
                else {Console.Clear();  Console.WriteLine("Наступил следующий ход"); }
                turnCounter++;
            }

            Console.WriteLine(mage.IsDEAD ? "Гоблин победил!" : "Маг победил!");
            Console.ReadKey();
        }
    }
}
