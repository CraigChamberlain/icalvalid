using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventCommentPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventCommentPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventCommentProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return new StringValidation(ResourceManager, evt, evt.Comments, "COMMENT").Validate();
        }

        #endregion
	}
}
