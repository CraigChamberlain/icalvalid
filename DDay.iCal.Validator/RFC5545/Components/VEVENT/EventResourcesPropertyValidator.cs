using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator.RFC5545
{
	public class EventResourcesPropertyValidator :
        EventValidation
	{
        #region Constructors

        public EventResourcesPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventResourcesProperty", calendars)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {
            return new StringValidation(ResourceManager, evt, evt.Resources, "RESOURCES").Validate();            
        }

        #endregion
	}
}
