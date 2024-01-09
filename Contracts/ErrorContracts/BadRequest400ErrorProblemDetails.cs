using System;
using Contracts.ErrorContracts;
using Results;

namespace digitalwedding.Contracts.ErrorContracts
{
	public class BadRequest400ErrorProblemDetails: ErrorProblemDetails
    {
		public object? code { get; private set; }
		public BadRequest400ErrorProblemDetails(Reason? errors = null)
		{
			status = 400;
			title = "Bad Request";

			if(errors != null)
			{
				detail = errors.Message;
				code = errors.Metadata.FirstOrDefault(s => s.Key == "Code").Value;
			}
		}
	}
}

