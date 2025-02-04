using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventUidPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventUidPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventUidProperty", calendars)
        {            
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "UID"),
                new StringValidation(ResourceManager, evt, evt.Uid, "UID")
            );
        }

        #endregion
	}
}
