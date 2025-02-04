using Ical.Net.CalendarComponents;

namespace Ical.Net.Validator
{
    public abstract class EventValidation :
        Validation
    {
        #region Public Properties

        public string Rule { get; set; }
        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public EventValidation(IResourceManager mgr, string rule, CalendarCollection calendars) :
            base(mgr)
        {
            Rule = rule;
            Calendars = calendars;
        }

        #endregion

        #region Protected Methods

        protected abstract IValidationResultCollection ValidateEvent(CalendarEvent evt);

        #endregion

        #region IValidator Members
                
        public override IValidationResultCollection Validate()
        {
            ValidationResultCollection result = new ValidationResultCollection(ResourceManager, Rule);
            result.Passed = true;

            if (Calendars != null)
            {
                foreach (Calendar calendar in Calendars)
                {
                    foreach (CalendarEvent evt in calendar.Events)
                        result.Add(ValidateEvent(evt));
                }
            }

            return result;
        }

        #endregion
    }
}
