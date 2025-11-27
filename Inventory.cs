using System;
using System.Collections.Generic;

namespace Dz_5
{
 internal class Inventory
 {
 private List<Item> items = new List<Item>();
 public int Capacity { get; }

 public Inventory(int capacity)
 {
 Capacity = capacity;
 }

 public bool Add(Item item)
 {
 if (item == null) return false;
 
 if (item is IStackable)
 {

 for (int i =0; i < items.Count; i++)
 {
 if (items[i].GetType() == item.GetType() && items[i] is IStackable stack)
 {
 stack.AddOne();
 return true;
 }
 }
 }

 if (items.Count >= Capacity)
 {
 Console.WriteLine("Инвентарь полон");
 return false;
 }
 items.Add(item);
 return true;
 }

 public void RemoveAt(int index)
 {
 if (index <0 || index >= items.Count)
 {
 Console.WriteLine("Неверный индекс");
 return;
 }
 items.RemoveAt(index);
 }

 public Item GetItem(int index)
 {
 if (index <0 || index >= items.Count)
 {
 Console.WriteLine("Неверный индекс");
 return null;
 }
 return items[index];
 }

 public void ShowInventory()
 {
 for (int i =0; i < items.Count; i++)
 {
 var it = items[i];
 if (it is IStackable st)
 {
 Console.WriteLine($"[{i}] {it.Name} x{st.Count} — {it.Description}");
 }
 else
 {
 Console.WriteLine($"[{i}] {it.Name} — {it.Description}");
 }
 }
 if (items.Count ==0) Console.WriteLine("Инвентарь пуст");
 }

 public int Count => items.Count;

 public void RemoveOneOrItem(int index)
 {
 var it = GetItem(index);
 if (it == null) return;
 if (it is IStackable st)
 {
 st.RemoveOne();
 if (st.Count <=0)
 {
 RemoveAt(index);
 }
 }
 else
 {
 RemoveAt(index);
 }
 }
 }
}
