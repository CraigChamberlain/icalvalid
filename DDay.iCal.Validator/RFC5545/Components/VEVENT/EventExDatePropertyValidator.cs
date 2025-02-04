using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventExDatePropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventExDatePropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventExDateProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            // FIXME: do some validation here
            return null;
        }

        #endregion
	}
}
