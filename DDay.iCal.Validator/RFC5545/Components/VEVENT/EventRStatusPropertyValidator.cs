using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventRStatusPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventRStatusPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventRStatusProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            // FIXME: do some validation here
            return null;
        }

        #endregion
	}
}
