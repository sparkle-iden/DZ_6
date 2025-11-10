using System;

namespace Dz_5
{
    class Program
    {
        static string[] goblins = new string[] { "Гоблин-воин", "Гоблин-лучник", "Гоблин-маг" };
        static string[] mageNames = new string[] { "Гендальф", "Мерлин", "Дамблдор" };

        static void Main()
        {
            Random random = new Random();
            Mage mage = new Mage(mageNames[random.Next(0, 2)]);
            Goblin goblin = new Goblin(goblins[random.Next(0, 2)]);

            BattelTime.StartBattle(mage, goblin);
            Console.WriteLine("Вывести стату y/n");
            if (Console.ReadLine()=="y"){
                BattelTime.ShowStats();
            }
            Console.WriteLine("Бой окончен. Нажмите любую клавишу для выхода.");
        }
    }
}
