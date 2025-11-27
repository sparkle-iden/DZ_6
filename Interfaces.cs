namespace Dz_5
{
 interface IUsable
 {
 void Use(Character user);
 }

 interface IEquipable
 {
 void Equip(Character user);
 }

 interface ISellable
 {
 int Price { get; }
 void Sell(Character user);
 }

 interface IDiscardable
 {
 void Discard();
 }

 interface IStackable
 {
 int Count { get; }
 void AddOne();
 void RemoveOne();
 }
}
