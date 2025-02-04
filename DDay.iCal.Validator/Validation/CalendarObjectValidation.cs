namespace Ical.Net.Validator
{
    public abstract class CalendarObjectValidation :
        Validation
    {
        #region Public Properties

        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public CalendarObjectValidation(IResourceManager mgr, CalendarCollection calendars) : base(mgr)
        {
            Calendars = calendars;
        }

        #endregion

        #region Protected Methods

        protected abstract IValidationResultCollection ValidateObject(ICalendarObject obj);

        #endregion

        #region IValidator Members

        public override IValidationResultCollection Validate()
        {            
            ValidationResultCollection result = new ValidationResultCollection(ResourceManager);
            result.Passed = true;
            
            if (Calendars != null)
            {
                foreach (Calendar calendar in Calendars)
                {
                    foreach (ICalendarObject obj in calendar.Children)
                        result.Add(ValidateObject(obj));
                }
            }

            return result;
        }

        #endregion
    }
}
