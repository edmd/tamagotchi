
namespace Tamagotchi
{
    public static class DefaultValues
    {
        public const int MaxValue = 100;
        public const int MinValue = 0;
        public const int Feed = 20;
        public const int Sleep = 20;
        public const int Play = 20;
        public const int Poo = 20;
    }

    public class Tamagotchi : ITamagotchi
    {
        public int Happiness { get; set; }

        public int Tiredness { get; set; }

        public int Hungriness { get; set; }

        public int Fullness { get; set; }

        public Tamagotchi(
            int happiness = DefaultValues.MaxValue, 
            int tiredness = DefaultValues.MinValue, 
            int hungriness = DefaultValues.MaxValue, 
            int fullness = DefaultValues.MinValue)
        {
            Happiness = happiness;
            Tiredness = tiredness;
            Hungriness = hungriness;
            Fullness = fullness;
        }

        public void Interval()
        {
            Happiness -= 1;
            Tiredness += 1;
            Hungriness += 1;
            Fullness -= 1;
        }

        public bool Feed(int food)
        {
            if(Fullness == DefaultValues.MaxValue)
            {
                return false;
            } else
            {
                Fullness += food;
                if (Fullness < DefaultValues.MaxValue)
                    Fullness = DefaultValues.MaxValue;

                Hungriness -= food;
                if (Hungriness < DefaultValues.MinValue)
                    Hungriness = DefaultValues.MinValue;

                return true;
            }
        }

        public bool Sleep(int rest)
        {
            if(Tiredness == DefaultValues.MinValue)
            {
                return false;
            } else
            {
                Tiredness -= rest;
                if (Tiredness < DefaultValues.MinValue)
                    Tiredness = DefaultValues.MinValue;

                return true;
            }
        }

        public bool Play(int fun)
        {
            if(Tiredness == DefaultValues.MaxValue)
            {
                return false;
            } else
            {
                Happiness += fun;
                if (Happiness > DefaultValues.MaxValue)
                    Happiness = DefaultValues.MaxValue;

                Tiredness += fun;
                if (Tiredness > DefaultValues.MaxValue)
                    Tiredness = DefaultValues.MaxValue;

                return true;
            }
        }

        public bool Poop(int poo)
        {
            if(Fullness == DefaultValues.MinValue)
            {
                return false;
            } else
            {
                Fullness -= poo;
                if (Fullness < DefaultValues.MinValue)
                    Fullness = DefaultValues.MinValue;

                return true;
            }
        }
    }
}
