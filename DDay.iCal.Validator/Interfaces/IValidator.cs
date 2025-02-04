namespace Ical.Net.Validator
{
    public interface IValidator
    {
        IResourceManager ResourceManager { get; }

        /// <summary>
        /// Validates, returning a list of IValidationResults that
        /// describe the validation that has taken place.
        /// </summary>
        IValidationResultCollection Validate();
    }
}
