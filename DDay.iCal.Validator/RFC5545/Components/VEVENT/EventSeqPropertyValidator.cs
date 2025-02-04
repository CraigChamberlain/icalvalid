using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventSeqPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventSeqPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventSeqProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(         
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "SEQUENCE")
            );
        }

        #endregion
	}
}
