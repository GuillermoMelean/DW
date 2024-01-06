using System;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Data.Models.Gateway.Wedding;
using digitalwedding.Application.Services;
using digitalwedding.Contracts.GuestContracts;
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

        [HttpGet("{wedding_id}")]
        public async Task<IActionResult> CreateGuest(string wedding_id)
        {
            Result<GetWeddingResponse> response = await _weddingService.GetWedding(wedding_id);

            return Ok(response.Value);
        }
    }
}

