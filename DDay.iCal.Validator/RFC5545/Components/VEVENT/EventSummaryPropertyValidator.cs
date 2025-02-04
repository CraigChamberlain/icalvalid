using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventSummaryPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventSummaryPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventSummaryProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "SUMMARY"),
                new StringValidation(ResourceManager, evt, evt.Summary, "SUMMARY")
            );
        }

        #endregion
	}
}
