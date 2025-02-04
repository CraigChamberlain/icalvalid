﻿namespace Ical.Net.Validator.RFC5545
{
    public class DateTimeValuesValidator : 
        Validation
    {
        #region Constructors

        public DateTimeValuesValidator(IResourceManager mgr, CalendarCollection calendars) :
            base(mgr)
        {
        }

        #endregion

        #region Overrides
        
        #endregion

        #region IValidator Members

        public override IValidationResultCollection Validate()
        {
            // NOTE: dateTimeValues.xml is validated using other validation methods.
            // However, each rule definition must have a corresponding validator 
            // in order to work properly.
            // FIXME: Is there a way we can configure things so this class
            // doesn't have to exist?
            return null;
        }

        #endregion
    }
}
