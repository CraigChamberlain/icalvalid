namespace Ical.Net.Validator.RFC5545
{
    public class MethodValidator :
        Validation
    {
        #region Public Properties

        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public MethodValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr)
        {
            Calendars = calendars;
        }

        #endregion

        #region IValidator Members

        public override IValidationResultCollection Validate()
        {
            ValidationResultCollection results = new ValidationResultCollection(ResourceManager);
            results.Passed = true;

            if (Calendars != null)
            {
                foreach (Calendar calendar in Calendars)
                {
                    results.Add(ValidationResult.GetCompositeResults(
                        ResourceManager,
                        "method",
                        new PropertyCountValidation(ResourceManager, calendar, "VCALENDAR", "METHOD")
                    ));
                }
            }

            return results;
        }

        #endregion
    }
}
