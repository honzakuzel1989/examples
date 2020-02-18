using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
#nullable enable
    class NullableReferenceTypes
    {
        string data;

        public NullableReferenceTypes(string? nullstr)
        {
            data = nullstr ?? string.Empty;
        }

        public NullableReferenceTypes(string notnullstr, int _)
        {
            data = notnullstr.ToString();
        }
    }
#nullable restore
}
