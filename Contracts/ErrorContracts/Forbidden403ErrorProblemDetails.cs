using digitalwedding.Contracts.ErrorContracts;

namespace Contracts.ErrorContracts
{
	public class Forbidden403ErrorProblemDetails : ErrorProblemDetails
    {
		public Forbidden403ErrorProblemDetails()
		{
            status = 403;
            title = "Forbidden";
            detail = "No permission to execute this endpoint";
        }
	}
}

