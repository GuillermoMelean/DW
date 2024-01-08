namespace Contracts.ErrorContracts
{
	public class MethodNotAllowed405: ErrorProblemDetails
	{
		public MethodNotAllowed405()
		{
            status = 405;
            title = "Method Not Allowed";
			detail = "The request method is not allowed";
        }
	}
} 