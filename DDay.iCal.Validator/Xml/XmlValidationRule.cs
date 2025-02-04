using System.Xml;

namespace Ical.Net.Validator.Xml
{
    public class XmlValidationRule :
        ValidationRule
    {
        string _File;

        public string File
        {
            get { return _File; }
            protected set { _File = value; }
        }

        public XmlValidationRule(IXmlDocumentProvider docProvider, XmlNode node, XmlNamespaceManager nsmgr)
        {
            if (node.Attributes["name"] != null)
                Name = node.Attributes["name"].Value;
            if (node.Attributes["file"] != null)
                File = node.Attributes["file"].Value;

            if (!string.IsNullOrEmpty(File))
            {
                try
                {
                    XmlDocument doc = docProvider.Load(File);
                    if (doc != null)
                    {
                        List<ITest> tests = new List<ITest>();

                        string prefix = nsmgr.LookupPrefix("http://icalvalid.wikidot.com/validation");
                        foreach (XmlNode passNode in doc.SelectNodes("/" + prefix + ":rule/" + prefix + ":pass", nsmgr))
                            tests.Add(new XmlCalendarTest(passNode, nsmgr));
                        foreach (XmlNode failNode in doc.SelectNodes("/" + prefix + ":rule/" + prefix + ":fail", nsmgr))
                            tests.Add(new XmlCalendarTest(failNode, nsmgr));

                        Tests = tests.ToArray();
                    }
                    else throw new ValidationRuleLoadException("The file could not be found at the following path: '" + File + "'.", this);
                }
                catch (ValidationRuleLoadException) { throw; }
                catch
                {
                    throw new ValidationRuleLoadException(this);
                }
            }            
        }

        public override Type ValidatorType
        {
            get
            {
                Type type = Type.GetType("Ical.Net.Validator.RFC5545." + Name + "Validator, Ical.Net.Validator", false, true);
                return type;                
            }
            protected set
            {
            }
        }
    }
}
