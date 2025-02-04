using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventRDatePropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventRDatePropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventRDateProperty", calendars)
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
