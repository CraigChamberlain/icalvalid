namespace Ical.Net.Validator
{
    public interface ITestable :
        ITestProvider
    {        
        ITestResult[] Test();
    }
}
