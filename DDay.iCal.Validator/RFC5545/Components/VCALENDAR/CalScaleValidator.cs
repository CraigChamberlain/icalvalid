namespace Ical.Net.Validator.RFC5545
{
    public class CalScaleValidator : 
        Validation
    {
        #region Public Properties

        public CalendarCollection Calendars { get; set; }

        #endregion

        #region Constructors

        public CalScaleValidator(IResourceManager mgr, CalendarCollection calendars) :
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
                        "calScale",
                        new PropertyCountValidation(ResourceManager, calendar, "VCALENDAR", "CALSCALE")
                    ));
                }
            }

            return results;
        }

        #endregion
    }
}
