namespace Contracts.ErrorContracts
{
	public class ErrorProblemDetails
	{
		public string title { get; set; }
        public int status { get; set; }
        public string? detail { get; set; }
    }
}

