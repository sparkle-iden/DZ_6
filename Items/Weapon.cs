using System;

namespace Dz_5
{
 internal class Weapon : Item, IEquipable
 {
 public int Damage { get; }
 public Weapon(string name, string desc, int dmg) : base(name, desc)
 {
 Damage = dmg;
 }
 public void Equip(Character user)
 {
 user.EquipWeapon(this);
 }
 }
}
