namespace Contracts.ErrorContracts
{
	public class Forbidden403 : ErrorProblemDetails
    {
		public Forbidden403()
		{
            status = 403;
            title = "Forbidden";
            detail = "No permission to execute this endpoint";
        }
	}
}

