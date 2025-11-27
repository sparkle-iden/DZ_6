using System;

namespace Dz_5
{
 internal class HealthPotion : Item, IUsable, IStackable
 {
 private int healAmount;
 private int count;
 public HealthPotion(int heal=15, int initialCount=1) : base("HealthPotion", "Восстанавливает здоровье")
 {
 healAmount = heal;
 count = initialCount;
 }

 public int Count => count;
 public void AddOne() => count++;
 public void RemoveOne() => count--;

 public void Use(Character user)
 {
 if (count <=0) return;
 user.AddHealth(healAmount);
 RemoveOne();
 Console.WriteLine($"Использовано зелье, восстановлено {healAmount}");
 }
 }
}
