using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventRelatedPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventRelatedPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventRelatedProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return new StringValidation(ResourceManager, evt, evt.RelatedComponents, "RELATED-TO").Validate();
        }

        #endregion
	}
}
