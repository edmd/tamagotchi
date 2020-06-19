using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi
{
    // Have refactored common methods to further abstract out the tamagotchi needs
    public interface INeed
    {
        int Value { get; }

        bool Increase(int value);

        bool Decrease(int value);
    }
}
