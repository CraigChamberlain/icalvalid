using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator
{
    public interface ITestError
    {
        string Name { get; }
        string Message { get; }
        string Source { get; }
        IValidationResultCollection ValidationResults { get; }
    }
}
