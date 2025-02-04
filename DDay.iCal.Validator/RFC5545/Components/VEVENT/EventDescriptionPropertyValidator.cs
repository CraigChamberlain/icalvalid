using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventDescriptionPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventDescriptionPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventDescriptionProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                 new PropertyCountValidation(ResourceManager, evt, "VEVENT", "DESCRIPTION"),
                 new StringValidation(ResourceManager, evt, evt.Description, "DESCRIPTION")
            );
        }

        #endregion
	}
}
