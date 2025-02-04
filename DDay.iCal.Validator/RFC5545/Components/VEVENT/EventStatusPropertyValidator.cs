using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventStatusPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventStatusPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventStatusProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "STATUS"),
                new PropertyValuesValidation(ResourceManager, evt, "VEVENT", "STATUS", "Tentative", "Confirmed", "Cancelled")
            );
        }

        #endregion
	}
}
