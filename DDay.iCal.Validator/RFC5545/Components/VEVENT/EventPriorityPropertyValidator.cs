using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventPriorityPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventPriorityPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventPriorityProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "PRIORITY")
            );
        }

        #endregion
	}
}
