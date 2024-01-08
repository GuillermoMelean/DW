using System;
using Results;

namespace digitalwedding.Application.Errors
{
	public class DatabaseError: Error
	{
		public DatabaseError() : base("Unexpected database error occurred.")
		{
			WithMetadata("Code", ErrorCodes.DatabaseError);
		}

        public DatabaseError(string message) : base(message)
        {
            WithMetadata("Code", ErrorCodes.DatabaseError);
        }
    }
}

