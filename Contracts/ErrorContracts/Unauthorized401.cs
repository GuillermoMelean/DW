namespace Contracts.ErrorContracts
{
	public class Unauthorized401 : ErrorProblemDetails
	{
		public Unauthorized401()
		{
			status = 401;
			title = "Unauthorized";
			detail = "Token Validation failed";
		}
	}
}

