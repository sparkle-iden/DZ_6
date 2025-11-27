using System;

namespace Dz_5
{
    class Program
    {
        static void Main()
        {
            Mage mage = new Mage("Гендальф");
            // наполним инвентарь
            mage.Inventory.Add(new HealthPotion(15,3));
            mage.Inventory.Add(new Food(10,2));
            mage.Inventory.Add(new Gem(50));
            mage.Inventory.Add(new OldBoot());
            mage.Inventory.Add(new Weapon("Меч", "Старый ржавый меч",5));
            mage.Inventory.Add(new Armor("Кожаная броня", "Легкая броня",3));
            mage.Inventory.Add(new MagicRing(120));
            mage.Inventory.Add(new Scroll(30));

            while (true)
            {
                Console.Clear();
                mage.ShowInfo();
                Console.WriteLine();
                Console.WriteLine("Инвентарь:");
                mage.Inventory.ShowInventory();
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Использовать предмет");
                Console.WriteLine("2 - Экипировать предмет");
                Console.WriteLine("3 - Продать предмет");
                Console.WriteLine("4 - Выбросить предмет");
                Console.WriteLine("0 - Выход");
                Console.Write("-> ");
                string action = Console.ReadLine();
                int act;
                if (!int.TryParse(action, out act)) continue;
                if (act ==0) break;
                Console.Write("Введите индекс предмета: ");
                string idxs = Console.ReadLine();
                int idx;
                if (!int.TryParse(idxs, out idx)) continue;
                var item = mage.Inventory.GetItem(idx);
                if (item == null) { Console.WriteLine("Предмет не найден"); Console.ReadKey(); continue; }
                switch (act)
                {
                    case 1:
                        if (item is IUsable u)
                        {
                            u.Use(mage);
                            mage.Inventory.RemoveOneOrItem(idx);
                        }
                        else Console.WriteLine("Этот предмет нельзя использовать");
                        break;
                    case 2:
                        if (item is IEquipable e)
                        {
                            e.Equip(mage);
                            // если экипируем — удаляем из инвентаря
                            mage.Inventory.RemoveAt(idx);
                        }
                        else Console.WriteLine("Этот предмет нельзя экипировать");
                        break;
                    case 3:
                        if (item is ISellable s)
                        {
                            s.Sell(mage);
                            mage.Inventory.RemoveOneOrItem(idx);
                        }
                        else Console.WriteLine("Этот предмет нельзя продать");
                        break;
                    case 4:
                        if (item is IDiscardable d)
                        {
                            d.Discard();
                            mage.Inventory.RemoveOneOrItem(idx);
                        }
                        else Console.WriteLine("Этот предмет нельзя выбросить");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
