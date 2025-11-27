using System;

namespace Dz_5
{
 internal class Armor : Item, IEquipable
 {
 public int ArmorValue { get; }
 public Armor(string name, string desc, int armor) : base(name, desc)
 {
 ArmorValue = armor;
 }
 public void Equip(Character user)
 {
 user.EquipArmor(this);
 }
 }
}
