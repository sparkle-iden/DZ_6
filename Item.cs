using System;

namespace Dz_5
{
 internal abstract class Item
 {
 public string Name { get; protected set; }
 public string Description { get; protected set; }

 protected Item(string name, string description)
 {
 Name = name;
 Description = description;
 }

 public virtual void ShowInfo()
 {
 Console.WriteLine($"{Name} — {Description}");
 }
 }
}
