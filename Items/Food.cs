using System;

namespace Dz_5
{
 internal class Food : Item, IUsable, IStackable
 {
 private int energyAmount;
 private int count;
 public Food(int energy=10, int initialCount=1) : base("Food", "Еда, восстанавливает энергию")
 {
 energyAmount = energy;
 count = initialCount;
 }

 public int Count => count;
 public void AddOne() => count++;
 public void RemoveOne() => count--;

 public void Use(Character user)
 {
 if (count <=0) return;
 user.AddEnergy(energyAmount);
 RemoveOne();
 Console.WriteLine($"Съедено, восстановлено энергии {energyAmount}");
 }
 }
}
