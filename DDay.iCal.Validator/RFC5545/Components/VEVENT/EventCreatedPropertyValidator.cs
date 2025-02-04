using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventCreatedPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventCreatedPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventCreatedProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "CREATED"),
                new iCalDateTimePropertyValidation(ResourceManager, evt, "CREATED")
            );
        }

        #endregion
	}
}
