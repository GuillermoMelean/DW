using System;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace digitalwedding.Controllers.api
{

    [ApiController]
    [Route("/api/guests/")]
    public class GuestsController : ControllerBase
    {
        [HttpPost("{wedding_id}")]
        public IActionResult CreateGuest(string wedding_id, [FromBody] CreateGuestContractRequest contract)
        {
            contract.first_name = wedding_id;

            return Ok(contract);
        }
    }
}

