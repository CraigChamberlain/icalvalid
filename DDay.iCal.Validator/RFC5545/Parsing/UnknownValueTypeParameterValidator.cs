using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Ical.Net.Validator.RFC5545
{
    public class UnknownValueTypeParameterValidator : 
        CalendarObjectValidation
    {
        #region Constructors

        public UnknownValueTypeParameterValidator(IResourceManager mgr, CalendarCollection calendars) : base(mgr, calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateObject(ICalendarObject obj)
        {
            ValidationResultCollection results = new ValidationResultCollection(ResourceManager);
            results.Passed = true;

            ICalendarPropertyListContainer c = obj as ICalendarPropertyListContainer;
            if (c != null)
            {
                List<string> validValues = new List<string>(new string[]
                {
                    "BINARY",
                    "BOOLEAN",
                    "CAL-ADDRESS",
                    "DATE",
                    "DATE-TIME",
                    "DURATION",
                    "FLOAT",
                    "INTEGER",
                    "PERIOD",
                    "RECUR",
                    "TEXT",
                    "TIME",
                    "URI",
                    "UTC-OFFSET"
                });

                foreach (ICalendarProperty p in c.Properties)
                {
                    foreach (CalendarParameter parm in p.Parameters)
                    {
                        if (parm.Values != null &&
                            parm.ValueCount > 0 &&
                            string.Equals(parm.Name, "VALUE", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (!validValues.Contains(parm.Values.First().ToUpper()))
                                Warning(results, "unknownValueTypeParameterError", p.Line, p.Column, parm.Values.First(), string.Join(", ", validValues.ToArray()));
                        }
                    }
                }
            }

            return results;
        }

        #endregion
    }
}
