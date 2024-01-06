using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Services;
using digitalwedding.Contracts.GuestContracts;
using Microsoft.AspNetCore.Mvc;

namespace digitalwedding.Controllers.api
{
    [ApiController]
    [Route("/api/guests/")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateGuest([FromBody] CreateGuestContractRequest contract)
        {
            await _guestService.CreateGuest(new CreateGuestRequest()
            {
               WeddingId = contract.wedding_id,
               FirstName = contract.first_name,
               LastName = contract.last_name,
               Email = contract.email,
               PhoneNumber = contract.phoneNumber,
               HasAllergies = contract.has_allergies,
               Allergies = contract.allergies,
               Diabetic = contract.diabetic,
               Celiac = contract.celiac,
               Vegan = contract.vegan,
               Vegetarian = contract.vegetarian,
               Attendance = contract.attendance,
               Message = contract.message
            });
            return NoContent();
        }
    }
}

