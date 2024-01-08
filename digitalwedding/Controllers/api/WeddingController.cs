using System;
using digitalwedding.Application.Data.Models.Gateway.Wedding;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Application.Services;
using digitalwedding.Contracts;
using digitalwedding.Contracts.ErrorContracts;
using digitalwedding.Contracts.WeddingContracts;
using digitalwedding.Extensions;
using Microsoft.AspNetCore.Mvc;
using Results;

namespace digitalwedding.Controllers.api
{
	[ApiController]
	[Route("/api/weddings/")]
	public class WeddingController : ControllerBase
	{
		private readonly IWeddingService _weddingService;

		public WeddingController(IWeddingService weddingService)
		{
			_weddingService = weddingService;
		}

        [HttpGet()]
        public async Task<IActionResult> GetWeddings([FromQuery] GetAllWeddingsContractRequest contract)
        {
            Result<PaginatedList<Wedding>> result = await _weddingService.GetAllWeddings(contract);

            return result.ToHttpResponseWithReasonError(() => Ok(new GetAllWeddingsContractResponse()
            {
                list = result.Value.Select(s => new GetWeddingContractResponse()
                {
                    first_name = s.FirstName,
                    second_name = s.SecondName,
                    id = s.Id,
                    url = s.Url,
                    wedding_date = s.WeddingDate
                }).ToList(),
                page_index = result.Value.PageIndex,
                page_size = result.Value.PageSize,
                total_pages = result.Value.TotalPages,
                total_records = result.Value.TotalRecords,
            }), (errors) => StatusCode(StatusCodes.Status400BadRequest, new BadRequest400ErrorProblemDetails(errors)));
        }

        [HttpGet("{wedding_id}")]
        public async Task<IActionResult> GetWeddingById(string wedding_id)
        {
            Result<GetWeddingResponse> result = await _weddingService.GetWedding(wedding_id);

            return result.ToHttpResponseWithReasonError(() => Ok(result.Value),
            (errors) => StatusCode(StatusCodes.Status400BadRequest, new BadRequest400ErrorProblemDetails(errors: errors)));
        }
    }
}

