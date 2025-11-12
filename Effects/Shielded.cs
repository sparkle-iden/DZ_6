using System;


namespace Dz_5.Effects
{
    class Shielded : Effect
    {
        public Shielded(Character target) : base("Щит", 3) {
            Start(target);
        }
        int armorBonus = 15;
        
      
        public override void Start(Character target)
        {
            Console.WriteLine($"{target.Name} защищен! Броня увеличена.");
            BattelTime.TotalCast.Add(this);
            target.tempArmor += armorBonus;
        }

        public override void EachTurn(Character target)
        {
            if (target.tempArmor != 0)
            {
                Turns--;
            }
            else
            {
                EndEffect();
                Console.WriteLine($"{target.Name} потерял щит. Броня уменьшена.");
                BattelTime.TotalCast.Remove(this);
            }
        }
        public override void EndEffect()
        {
            Console.WriteLine("Эффект щита кончился");

        }
    }
}
