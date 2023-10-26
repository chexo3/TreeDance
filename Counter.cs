using System;
using System.Runtime.Versioning;

namespace TreeDance
{
    // Unfinished helper class because I am doing a whole lot of counting. Will have a method for incrementing and decrementing.
    [RequiresPreviewFeatures]
    internal class Counter<T> where T : INumber<T>
    {

        private T _value;
        private T _min;
        private T _max;
        public Counter(T value, T min, T max)
        {

            _value = T.Clamp(value, min, max);
            _min = min;
            _max = max;
        }

        public T Value
        {
            get => _value;

            set
            {
                _value = T.Clamp(value, _min, _max);
            }
        }

        public T Min
        {
            get => _min;

            set
            {
                _min = value;
                _value = T.Clamp(value, _min, _max);
            }
        }

        public T Max
        {
            get => _max;

            set
            {
                _max = value;
                _value = T.Clamp(value, _min, _max);
            }
        }

        /*
        
        Basically the idea is that I will be able to do something like:

        private Counter<byte> ByteCounter = new Counter<byte>(0, byte.MinValue, byte.MaxValue);

        Then later I can do:

        ByteCounter += 1; (this specific one would need operator overloading which is not implemented right now. really it'd be ByteCounter.value += 1;)

        And it will clamp it to the values I set initially. So, essentially an extension of the base type it was provided to have custom bounds.

        */

    }
}
