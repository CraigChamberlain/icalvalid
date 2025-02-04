using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventCategoriesPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventCategoriesPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventCategoriesProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return new StringValidation(ResourceManager, evt, evt.Categories, "CATEGORIES").Validate();
        }

        #endregion
	}
}
