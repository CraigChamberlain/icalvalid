using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventOrganizerPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventOrganizerPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventOrganizerProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "ORGANIZER")
            );
        }

        #endregion
	}
}
