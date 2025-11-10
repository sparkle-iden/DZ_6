using System;

namespace Dz_5
{
    abstract class Spell
    {
        public string Name;
        public string Description;
        public int Cooldown;
        public int CurrentCooldown = 0;

        public bool CanCast()
        {
            return CurrentCooldown == 0;
        }

        public void StartCooldown()
        {
            CurrentCooldown = Cooldown;
        }

        public void UpdateCooldown()
        {
            if (CurrentCooldown > 0)
                CurrentCooldown--;
        }

        public abstract void Cast(Character target);
    }

    
}