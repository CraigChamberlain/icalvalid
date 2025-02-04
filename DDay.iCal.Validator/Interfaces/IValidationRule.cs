using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator
{
    public interface IValidationRule :
        ITestProvider
    {
        string Name { get; }
        Type ValidatorType { get; }
    }
}
