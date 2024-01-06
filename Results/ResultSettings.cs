using System;
namespace Results
{
	public class ResultSettings
	{
		public IResultLogger Logger { get; set; }
		public Func<Exception, Error> DefaultTryCatchHandler { get; set; }
	}
}

