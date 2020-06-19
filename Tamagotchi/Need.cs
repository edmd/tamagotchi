using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi
{
    public class Need : INeed
    {
        public int Value { get; protected set; }

        public Need(int value)
        {
            Value = value;
        }

        public bool Increase(int value)
        {
            if (Value == DefaultValues.MaxValue)
            {
                return false;
            }

            Value += value;
            if (Value > DefaultValues.MaxValue)
                Value = DefaultValues.MaxValue;

            return true;
        }

        public bool Decrease(int value)
        {
            if (Value == DefaultValues.MinValue)
            {
                return false;
            }
            else
            {
                Value -= value;
                if (Value < DefaultValues.MinValue)
                    Value = DefaultValues.MinValue;

                return true;
            }
        }
    }
}