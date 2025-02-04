using System.Xml;

namespace Ical.Net.Validator.Xml
{
    public class ZipXmlDocumentProvider : 
        ZipExtractor,
        IXmlDocumentProvider
    {
        public ZipXmlDocumentProvider(string zipFilepath) : base(zipFilepath)
        {
        }

        #region IXmlDocumentProvider Members

        public XmlDocument Load(string pathToFileWithinZip)
        {
            string contents = LoadXml(pathToFileWithinZip);
            if (contents != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(contents);
                return xmlDoc;
            }

            return null;
        }

        public string LoadXml(string pathToFileWithinZip)
        {
            return GetFileContents(pathToFileWithinZip);
        }

        #endregion
    }
}
