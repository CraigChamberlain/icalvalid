namespace Ical.Net.Validator.RFC5545
{
    public class LineFoldingValidator :
        Validation
    {
        #region Public Properties

        public string iCalText { get; set; }

        #endregion

        #region Constructors

        public LineFoldingValidator(IResourceManager mgr, string cal_text) :
            base(mgr)
        {
            iCalText = cal_text;
        }

        #endregion

        #region IValidator Members

        public override IValidationResultCollection Validate()
        {
            ValidationResultCollection result = new ValidationResultCollection(ResourceManager, "lineFolding");

            try
            {
                StringReader sr = new StringReader(iCalText);
                Calendar calendar = Calendar.Load(sr);

                result.Passed = true;
            }
            catch (Exception ex) { throw ex; }
            //TODO work out if Antlr4 has a Mismatch token and what to do with it?
            //
            //catch (Antlr4. ex)
            //{
            //    if (ex.expecting == 6 && // COLON = 6
            //        ex.mismatchType ==  Antlr4.MismatchedTokenException.TokenTypeEnum.TokenType)
            //        Fatal(result, "lineFoldingWithoutSpaceError", ex.line, ex.column, ex.Message, null);
            //}

            return result;
        }

        #endregion
    }
}
