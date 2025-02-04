using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
	public class EventContactPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventContactPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventContactProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return new StringValidation(ResourceManager, evt, evt.Contacts, "CONTACT").Validate();            
        }

        #endregion
    }
}
