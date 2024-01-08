using System;
using Microsoft.AspNetCore.Mvc;
using Results;

namespace digitalwedding.Extensions
{
	public static class HttpResult
	{
		public static IActionResult ToHttpResponse<T>(this Result<T> result, Func<IActionResult> successAction, Func<List<Dictionary<string, object>>, IActionResult> errorAction)
		{
			if (result.IsSuccess)
			{
				return successAction.Invoke();
			}

			List<Dictionary<string, object>> errorsMetadata = new ();

			foreach (var error in result.Reasons)
			{
				if(error.HasMetadataKey("Code"))
				{
					errorsMetadata.Add(error.Metadata);
				}
			}

			return errorAction.Invoke(errorsMetadata);
		}

        public static IActionResult ToHttpResponse(this Result result, Func<IActionResult> successAction, Func<List<Dictionary<string, object>>, IActionResult> errorAction)
        {
            if (result.IsSuccess)
            {
                return successAction.Invoke();
            }

            List<Dictionary<string, object>> errorsMetadata = new List<Dictionary<string, object>>();

            foreach (var error in result.Reasons)
            {
                if (error.HasMetadataKey("Code"))
                {
                    errorsMetadata.Add(error.Metadata);
                }
            }

            return errorAction.Invoke(errorsMetadata);
        }

        public static IActionResult ToHttpResponseWithReasonError<T>(this Result<T> result, Func<IActionResult> successAction, Func<Reason, IActionResult> errorAction)
        {
            if (result.IsSuccess)
            {
                return successAction.Invoke();
            }

            return errorAction.Invoke(result.Reasons.FirstOrDefault());
        }

        public static IActionResult ToHttpResponseWithReasonError(this Result result, Func<IActionResult> successAction, Func<Reason, IActionResult> errorAction)
        {
            if (result.IsSuccess)
            {
                return successAction.Invoke();
            }

            return errorAction.Invoke(result.Reasons.FirstOrDefault());
        }
    }
}

