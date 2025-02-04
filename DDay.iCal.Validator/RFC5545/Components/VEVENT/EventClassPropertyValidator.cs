using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ical.Net.Validator.RFC5545
{
    public class EventClassPropertyValidator :
        EventValidation
    {
        #region Public Properties

        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public EventClassPropertyValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr, "eventClassProperty", calendars)
        {
            Calendars = calendars;
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateEvent(CalendarEvent evt)
        {            
            return ValidationResult.GetCompositeResults(
                ResourceManager,
                new PropertyCountValidation(ResourceManager, evt, "VEVENT", "CLASS"),
                new PropertyValuesValidation(ResourceManager, evt, "VEVENT", "CLASS", "PUBLIC", "PRIVATE", "CONFIDENTIAL"),
                new StringValidation(ResourceManager, evt, evt.Class, "CLASS")
            );
        }

        #endregion
    }
}
