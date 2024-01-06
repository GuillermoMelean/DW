using System;
namespace Results
{
	public interface IResultLogger
	{
		void Log(string context, ResultBase result);
	}
}

