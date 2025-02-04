using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventTranspPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventTranspPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventTranspProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "TRANSP")
            );
        }

        #endregion
	}
}
