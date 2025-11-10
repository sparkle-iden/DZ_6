using System;


namespace Dz_5.Effects
{
    abstract class Effect
    {
        public string Name;
        public int Turns;

        public Effect(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }

        public abstract void Start(Character target);
        public abstract void EachTurn(Character target);
        public abstract void EndEffect();
    }
}
