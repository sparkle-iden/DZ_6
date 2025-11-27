using System;

namespace Dz_5
{
 internal class MagicRing : Item, IEquipable, ISellable
 {
 private int price;
 public MagicRing(int price=100) : base("MagicRing", "Волшебное кольцо")
 {
 this.price = price;
 }
 public int Price => price;
 public void Equip(Character user)
 {
 user.EquipRing(this);
 }
 public void Sell(Character user)
 {
 user.AddGold(Price);
 Console.WriteLine($"Кольцо продано за {Price}");
 }
 }
}
