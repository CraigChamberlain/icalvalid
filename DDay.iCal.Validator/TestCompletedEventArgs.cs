namespace Ical.Net.Validator
{
    public class TestCompletedEventArgs :
        EventArgs
    {
        public ITestResult Result { get; set; }

        public TestCompletedEventArgs(ITestResult result)
        {
            Result = result;
        }
    }
}
