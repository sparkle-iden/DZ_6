using Dz_5.Effects;
using System;
using System.Collections.Generic;
using System.Xml.Schema;


namespace Dz_5
{
   
    static internal class BattelTime
    {
        public static int TotalDamage;
        public static int TotalHeal;
        public static List<Effect> TotalCast = new List<Effect>();
        public static int HpWin;
        static public void StartBattle(Mage mage, Goblin goblin)
        {
            
            BattleLogger.Start("battle_log.txt");

            try
            {
                Console.WriteLine("Бой начинается!");
                int turnCounter = 1;
                bool isBattleOver = false;

                while (!mage.IsDEAD && !goblin.IsDEAD && !isBattleOver)
                {
                    Console.Clear();
                    Console.WriteLine($"\n--- Ход {turnCounter} ---");
                    Console.WriteLine($"Здоровье: {mage.Name} {mage.Health}");
                    Console.WriteLine($"Здоровье: {goblin.Name} {goblin.Health}\n");

                    mage.UpdateEffect();

                    Console.WriteLine($"Ход {mage.Name}");
                    mage.ShowSpells();

                    Console.WriteLine("Выберите заклинание (1-3):");
                    string input = Console.ReadLine();
                    Console.WriteLine("Выберите таргет : 1. Гоблин   2. Себя");
                    string inputTarget = Console.ReadLine();

                    int spellChoice;
                    int targetChoice;
                    if (int.TryParse(inputTarget, out targetChoice) &&
                        (targetChoice == 1 || targetChoice == 2) &&
                        int.TryParse(input, out spellChoice) &&
                        spellChoice >= 1 && spellChoice <= mage.Spelist.Length)
                    {
                        Character target = targetChoice == 1 ? (Character)goblin : mage;
                        mage.CastSpell(spellChoice - 1, target);
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор! Пропуск хода.");
                    }

                    for (int i = 0; i < mage.Spelist.Length; i++)
                    {
                        if (mage.Spelist[i].CurrentCooldown > 0)
                        {
                            mage.Spelist[i].UpdateCooldown();
                        }
                    }

                    if (goblin.IsDEAD || mage.IsDEAD) break;

                    goblin.UpdateEffect();
                    Console.WriteLine($"\nХод {goblin.Name}");
                    int damage = goblin.Attack();
                    mage.ApplyDamage(damage);
                    TotalDamage += damage;

                    if (mage.IsDEAD || goblin.IsDEAD) break;

                    Console.WriteLine("\nПродолжить бой? (any/n)");
                    if (Console.ReadLine() == "n")
                    {
                        Console.WriteLine("Бой закончен");
                        isBattleOver = true;
                    }
                    else
                    {
                        Console.WriteLine("Наступил следующий ход");
                    }

                    turnCounter++;
                }

                if (isBattleOver)
                {
                    Console.WriteLine("Бой был прерван.");
                }
                else
                {
                    if(goblin.IsDEAD)
                    {
                        HpWin = mage.Health;
                    }else
                    {
                        HpWin = goblin.Health;
                    }
                    Console.WriteLine(mage.IsDEAD ? "Гоблин победил!"  : "Маг победил!");
                }

                Console.ReadKey();
            }
            finally
            {
                BattleLogger.Stop();
            }
        }

        public static void ShowStats()
        {
            Console.WriteLine("\n--- Статистика боя ---");
            Console.WriteLine($"Общий нанесенный урон: {TotalDamage}");
            Console.WriteLine($"Общее исцеление: {TotalHeal}");
            Console.WriteLine($"Здоровье победителя: {HpWin}");
            Console.WriteLine("Примененные эффекты:");
            foreach (var effect in TotalCast)
            {
                Console.WriteLine($"- {effect.Name}");
            }
        }
    }
}

