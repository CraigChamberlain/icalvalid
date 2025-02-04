using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventDTEndPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventDTEndPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventDTEndProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", new string[] { "DTEND", "DURATION" }, true),
                new iCalDateTimePropertyValidation(ResourceManager, evt, "DTEND")
            );
        }

        #endregion
	}
}
