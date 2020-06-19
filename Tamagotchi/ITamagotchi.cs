namespace Tamagotchi
{
    public interface ITamagotchi
    {
        int Fullness { get; set; }
        int Happiness { get; set; }
        int Hungriness { get; set; }
        int Tiredness { get; set; }

        void Interval();

        bool Feed(int food);
        bool Play(int fun);
        bool Poop(int poo);
        bool Sleep(int rest);
    }
}