using System;


namespace Dz_5.Effects
{
    class Shielded : Effect
    {
        public Shielded(Character target) : base("Щит", 3) {
            Start(target);
        }
        int armorBonus = 5;
        
      
        public override void Start(Character target)
        {
            Console.WriteLine($"{target.Name} защищен! Броня увеличена.");
            BattelTime.TotalCast.Add(this);
        }

        public override void EachTurn(Character target)
        {
            target.tempArmor += armorBonus;
            
            Console.WriteLine($"{target.Name} под щитом. Осталось ходов: {Turns}");
            Turns--;
        }
        public override void EndEffect()
        {
            Console.WriteLine("Эффект щита кончился");

        }
    }
}
