using System;

namespace Dz_5
{
 internal class Scroll : Item, IUsable, ISellable
 {
 private int price;
 public Scroll(int price=25) : base("Scroll", "Свиток с магией")
 {
 this.price = price;
 }
 public int Price => price;
 public void Use(Character user)
 {
 Console.WriteLine("Свиток использован — ничего не произошло");
 }
 public void Sell(Character user)
 {
 user.AddGold(Price);
 Console.WriteLine($"Свиток продан за {Price}");
 }
 }
}
