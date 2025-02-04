using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventExRulePropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventExRulePropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventExRuleProperty", calendars)
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
