using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
    public class EventUrlPropertyValidator :
        EventValidation
    {
        #region Constructors

        public EventUrlPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventUrlProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "URL"),
                new UriPropertyValidation(ResourceManager, evt, "URL")
            );
        }

        #endregion
    }
}
