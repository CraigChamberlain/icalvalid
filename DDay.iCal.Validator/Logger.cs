namespace Ical.Net.Validator
{

	public class ConsoleLogger : ILogger
	{

		public void LogMessage(string message)
		{
			Console.WriteLine(message);
		}

		public void SetStatus(string status)
		{
			Console.WriteLine("status: " + status);
		}

	}

	public class NullLogger : ILogger
	{

		public void LogMessage(string message)
		{
		}

		public void SetStatus(string status)
		{
		}

	}

}
