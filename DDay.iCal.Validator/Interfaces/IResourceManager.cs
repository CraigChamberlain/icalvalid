using Ical.Net.Validator.Xml;

namespace Ical.Net.Validator
{
    public interface IResourceManager
    {
        string CurrentLanguageIdentifier { get; }
        bool Initialize(IXmlDocumentProvider docProvider, bool forceEnglishOnNotFound);
        bool Initialize(IXmlDocumentProvider docProvider, string language);
        string GetString(string key);
        string GetError(string key);
        string[] GetResolutions(string key);
    }
}
