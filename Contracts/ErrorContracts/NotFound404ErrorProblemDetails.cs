using System;
using Contracts.ErrorContracts;

namespace digitalwedding.Contracts.ErrorContracts
{
	public class NotFound404ErrorProblemDetails: ErrorProblemDetails
    {
		public NotFound404ErrorProblemDetails()
		{
			status = 404;
			title = "Not Found";
			detail = "Resource not found";
		}

        public NotFound404ErrorProblemDetails(string message)
        {
            status = 404;
            title = "Not Found";
            detail = message;
        }
    }
}

