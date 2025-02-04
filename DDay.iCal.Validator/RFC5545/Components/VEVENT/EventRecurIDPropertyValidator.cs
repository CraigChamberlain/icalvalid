using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventRecurIDPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventRecurIDPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventRecurIDProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "RECURRENCE-ID"),
                new iCalDateTimePropertyValidation(ResourceManager, evt, "RECURRENCE-ID")
            );
        }

        #endregion
	}
}
