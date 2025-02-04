using Ical.Net.DataTypes;
using Ical.Net.CalendarComponents;
using System.Text.RegularExpressions;

namespace Ical.Net.Validator
{
    public class iCalDateTimePropertyValidation :
        PropertyValidation
    {       
        #region Constructors

        public iCalDateTimePropertyValidation(IResourceManager mgr, ICalendarPropertyListContainer obj, string propertyName) :
            base(mgr, obj, propertyName)
        {
        }

        #endregion

        #region Overrides

        protected override IValidationResultCollection ValidateProperty(ICalendarProperty p)
        {
            ValidationResultCollection result = new ValidationResultCollection(ResourceManager);
            if (p != null)
            {
                result.Passed = true;

                // Ensure that the date-time (or date) value is formatted properly
                bool hasTime = true;
                if (p.Parameters.ContainsKey("VALUE") &&
                    // TODO
                    // May need to spit this or change DATE
                    string.Equals(p.Parameters.Get("VALUE"), "DATE"))
                {
                    hasTime = false;
                }

                if (p.Value is string)
                {
                    // If the value is a string value, then it didn't
                    // get properly parsed into an IDateTime value.
                    string value = p.Value.ToString();

                    string dateOnlyPattern = @"^\d{8}$";
                    string fullPattern = @"^\d{8}T\d{6}(Z)?$";
                    
                    if (hasTime && Regex.IsMatch(value, dateOnlyPattern))
                        Error(result, "missingValueDateError", p.Line, p.Column, value);
                    else if (!hasTime && Regex.IsMatch(value, fullPattern))
                        Error(result, "valueDateIncorrectlyUsedError", p.Line, p.Column, value);
                    else if (hasTime)
                        Error(result, "invalidDateTimeFormatError", p.Line, p.Column, value);
                    else
                        Error(result, "invalidDateFormatError", p.Line, p.Column, value);
                }
                else if (p.Value is IDateTime)
                {
                    // Validate date/time ranges on the valid date/time value.
                    IDateTime dt = (IDateTime)p.Value;

                    if (// The maximum representable date/time on .NET systems
                        dt.Value.Equals(DateTime.MinValue) ||
                        dt.Value.Equals(DateTime.MaxValue) ||
                        // The maximum representable date/time on 32-bit Unix systems.
                        dt.Value < new DateTime(1901, 12, 13) ||
                        dt.Value > new DateTime(2038, 1, 19) ||
                        // Representable date/times on SQL Server 200X
                        dt.Value < new DateTime(1753, 1, 1) ||
                        dt.Value > new DateTime(2079, 6, 6))
                    {
                        Warning(result, "dateOutOfRangeError", p.Line, p.Column, p.Value);
                    }
                    else
                    {
                        // Ensure that, if a time zone was provided on the date-time property,
                        // that the corresponding time zone is contained in the calendar.
                        if (dt.TzId != null)
                        {
                            VTimeZone tz = p.Calendar.TimeZones.Where(t => t.TzId == dt.TzId).First();
                            if (tz == null)
                                Error(result, "timeZoneNotFoundError", p.Line, p.Column, dt.TzId);
                        }
                    }
                }                   
            }

            return result;
        }

        #endregion
    }
}
