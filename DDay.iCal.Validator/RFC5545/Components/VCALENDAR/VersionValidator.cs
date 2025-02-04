using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Ical.Net.Validator.RFC5545
{
    public class VersionValidator :
        Validation
    {
        #region Public Properties

        public string iCalText { get; set; }
        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public VersionValidator(IResourceManager mgr, string icalText, CalendarCollection calendars) :
            base(mgr)
        {
            iCalText = icalText;
            Calendars = calendars;
        }

        #endregion

        #region IValidator Members

        public override IValidationResultCollection Validate()
        {
            ValidationResultCollection result = new ValidationResultCollection(ResourceManager, "version");

            foreach (Calendar calendar in Calendars)
            {
                result.Add(
                    ValidationResult.GetCompositeResults(
                        ResourceManager,
                        new PropertyCountValidation(ResourceManager, calendar, "VCALENDAR", "VERSION", 1, 1)
                    )
                );

                if (BoolUtil.IsTrue(result.Passed))
                {
                    try
                    {
                        // Ensure the "VERSION" property can be parsed as a version number.
                        Version v = new Version(calendar.Version);
                        Version req = new Version(2, 0);
                        if (req > v)
                        {
                            // Ensure the "VERSION" is at least version 2.0.
                            Error(result, "versionGE2_0Error");
                        }

                        // Ensure the VERSION property is the first property encountered on the calendar.
                        StringReader sr = new StringReader(iCalText);
                        string line = sr.ReadLine();
                        bool hasBegun = false;
                        while (line != null)
                        {
                            if (hasBegun)
                            {
                                if (!line.StartsWith("VERSION", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    Warning(result, "versionFirstError");
                                }
                                break;
                            }

                            if (line.StartsWith("BEGIN:VCALENDAR", StringComparison.InvariantCultureIgnoreCase))
                                hasBegun = true;

                            line = sr.ReadLine();
                        }
                    }
                    catch
                    {
                        Error(result, "versionNumberError");
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
