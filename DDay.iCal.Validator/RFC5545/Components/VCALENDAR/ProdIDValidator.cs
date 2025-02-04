using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Ical.Net.Validator.RFC5545
{
    public class ProdIDValidator :
        Validation
    {
        #region Public Properties

        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public ProdIDValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr)
        {
            Calendars = calendars;
        }

        #endregion

        #region IValidator Members

        public override IValidationResultCollection Validate()
        {
            ValidationResultCollection results = new ValidationResultCollection(ResourceManager);
            results.Passed = true;

            if (Calendars != null)
            {
                foreach (Calendar calendar in Calendars)
                {
                    results.Add(ValidationResult.GetCompositeResults(
                        ResourceManager,
                        "prodID",
                        new PropertyCountValidation(ResourceManager, calendar, "VCALENDAR", "PRODID", 1, 1)
                    ));
                }
            }

            return results;
        }

        #endregion
    }
}
