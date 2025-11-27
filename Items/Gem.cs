using System;

namespace Dz_5
{
 internal class Gem : Item, ISellable
 {
 private int price;
 public Gem(int price=50) : base("Gem", "Драгоценный камень")
 {
 this.price = price;
 }
 public int Price => price;
 public void Sell(Character user)
 {
 user.AddGold(Price);
 Console.WriteLine($"Продан камень за {Price}");
 }
 }
}
