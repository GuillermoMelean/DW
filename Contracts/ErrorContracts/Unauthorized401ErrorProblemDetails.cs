using digitalwedding.Contracts.ErrorContracts;

namespace Contracts.ErrorContracts
{
	public class Unauthorized401ErrorProblemDetails : ErrorProblemDetails
    {
		public Unauthorized401ErrorProblemDetails()
		{
			status = 401;
			title = "Unauthorized";
			detail = "Token Validation failed";
		}
	}
}

