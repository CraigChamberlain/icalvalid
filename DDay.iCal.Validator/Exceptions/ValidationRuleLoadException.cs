namespace Ical.Net.Validator
{
    public class ValidationRuleLoadException :
        Exception
    {
        public IValidationRule ValidationRule { get; set; }

        public ValidationRuleLoadException(IValidationRule rule) : this(null, rule)
        {            
        }

        public ValidationRuleLoadException(string msg, IValidationRule rule) : base("The '" + rule.Name + "' validation rule failed to load. " + msg)
        {
            ValidationRule = rule;
        }
    }
}
