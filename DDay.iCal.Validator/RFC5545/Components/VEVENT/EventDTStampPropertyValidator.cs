using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventDTStampPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventDTStampPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventDTStampProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "DTSTAMP"),
                new iCalDateTimePropertyValidation(ResourceManager, evt, "DTSTAMP")
            );
        }

        #endregion
	}
}
