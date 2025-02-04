using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventLocationPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventLocationPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventLocationProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "LOCATION"),
                new StringValidation(ResourceManager, evt, evt.Location, "LOCATION")
            );
        }

        #endregion
	}
}
