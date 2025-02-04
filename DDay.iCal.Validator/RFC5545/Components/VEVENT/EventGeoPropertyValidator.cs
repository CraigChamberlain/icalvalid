using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventGeoPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventGeoPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventGeoProperty", calendars)
        {            
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "GEO")
            );
        }

        #endregion
	}
}
