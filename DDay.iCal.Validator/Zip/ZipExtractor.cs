using System.IO.Compression;
using System.Text;


namespace Ical.Net.Validator
{
    public class ZipExtractor : 
        IDisposable,
        IEnumerable<string>
    {
        ZipArchive _ZipArchive = null;

        public ZipExtractor(string zipFilepath)
        {
            _ZipArchive = ZipFile.OpenRead(zipFilepath);

        }

        virtual public string GetFileContents(string pathToFileWithinZip)
        {
            if (_ZipArchive != null)
            {
                var entry = _ZipArchive.GetEntry(pathToFileWithinZip);
                if (entry is not null)
                {
                    
                    StringBuilder sb = new StringBuilder();
                    StringWriter sw = new StringWriter(sb);

                    string result = null;
                         
                    Stream zis = entry.Open();
                    if (zis != null)
                    {
                        StreamReader sr = new StreamReader(zis);
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    return result;
                }
            }
            return null;
        }

        #region IDisposable Members

        virtual public void Dispose()
        {
            if (_ZipArchive != null)
            {
                _ZipArchive.Dispose();
            }
        }

        #endregion

        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            List<string> files = new List<string>();
            if (_ZipArchive != null)
            {
                foreach (ZipArchiveEntry ze in _ZipArchive.Entries)
                    files.Add(ze.Name);
            }

            return files.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)this).GetEnumerator();
        }

        #endregion
    }
}
