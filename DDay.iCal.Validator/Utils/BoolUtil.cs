using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator
{
    static public class BoolUtil
    {
        static public bool IsTrue(bool? value)
        {
            return (value != null && value.HasValue && value.Value);
        }
    }
}
