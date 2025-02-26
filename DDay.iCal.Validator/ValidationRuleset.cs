﻿
namespace Ical.Net.Validator
{
    public class ValidationRuleset : 
        IValidationRuleset
    {
        #region IValidationRuleset Members

        public string Name { get; protected set; }
        public string NameString { get; protected set; }
        public string DescriptionString { get; protected set; }
        public IValidationRule[] Rules { get; protected set; }

        #endregion
    }
}
