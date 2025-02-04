using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventDurationPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventDurationPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventDurationProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "DURATION")
            );
        }

        #endregion
	}
}
