using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator
{
    public interface ITestProvider
    {
        ITest[] Tests { get; }
    }
}
