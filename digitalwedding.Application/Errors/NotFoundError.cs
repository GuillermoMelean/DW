using System;
using Results;

namespace digitalwedding.Application.Errors
{
	public class NotFoundError : Error
	{

        public NotFoundError() : base("The resource you're looking for was not found.")
        {
            WithMetadata("Code", ErrorCodes.NotFoundError);
        }

        public NotFoundError(string message) : base(message)
        {
            WithMetadata("Code", ErrorCodes.NotFoundError);
        }
    }
}

