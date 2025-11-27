using System;

namespace Dz_5
{
 internal class OldBoot : Item, IDiscardable
 {
 public OldBoot() : base("OldBoot", "Старый ботинок — никому не нужен") { }
 public void Discard()
 {
 Console.WriteLine("Ботинок выброшен");
 }
 }
}
