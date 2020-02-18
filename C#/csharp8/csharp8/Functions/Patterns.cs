using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
    class Patterns
    {
        public enum Values { NEGATIVE, ZERO, POSITIVE }

        public int Sign(Values? v) => v switch
        {
            Values.NEGATIVE => -1,
            Values.ZERO => 0,
            Values.POSITIVE => 1,
            // NULL handling
            null => 0,
            // Default value
            _ => throw new ArgumentException(nameof(v)),
        };

        public Values Sign(int? v) => v switch
        {
            null => Values.ZERO,
            _ when v.Value > 0 => Values.POSITIVE,
            _ when v.Value < 0 => Values.NEGATIVE,
            _ => Values.ZERO
        };

        public bool IsInitialVersion(Version v) => v switch
        {
            // Property from v
            { Major: 1 } => true,
            _ => false
        };

        public char ResultSignTable(char left, char right) => (left, right) switch
        {
            ('+', '-') => '-',
            ('-', '+') => '-',
            ('+', '+') => '+',
            ('-', '-') => '+',

            _ => throw new ArgumentException()
        };
    }
}
