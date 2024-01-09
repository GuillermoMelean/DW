using digitalwedding.Contracts.ErrorContracts;

namespace Contracts.ErrorContracts
{
	public class MethodNotAllowed405ErrorProblemDetails: ErrorProblemDetails
    {
		public MethodNotAllowed405ErrorProblemDetails()
		{
            status = 405;
            title = "Method Not Allowed";
			detail = "The request method is not allowed";
        }
	}
} 