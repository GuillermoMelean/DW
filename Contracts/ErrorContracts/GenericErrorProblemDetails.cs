using System;
using Contracts.ErrorContracts;
using Results;

namespace digitalwedding.Contracts.ErrorContracts
{
    public class GenericErrorProblemDetails : ErrorProblemDetails
    {
        // Other properties and methods in the base class

        //public static GenericErrorProblemDetails Create(int statusCode)
        //{
        //    switch (statusCode)
        //    {
        //        case 400:
        //            return new BadRequest400ErrorProblemDetails();
        //        case 401:
        //            return new Unauthorized401ErrorProblemDetails();
        //        case 403:
        //            return new Forbidden403ErrorProblemDetails();
        //        case 404:
        //            return new NotFound404ErrorProblemDetails();
        //        // Add more cases as needed
        //        default:
        //            return new GenericErrorProblemDetails();
        //    }
        //}
    }
}

