using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Application.Services;
using digitalwedding.Contracts;
using digitalwedding.Contracts.ErrorContracts;
using digitalwedding.Contracts.GuestContracts;
using digitalwedding.Contracts.WeddingContracts;
using digitalwedding.Extensions;
using Microsoft.AspNetCore.Mvc;
using Results;

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

        [HttpGet()]
        public async Task<IActionResult> GetGuests([FromQuery] GetAllGuestsContractRequest contract)
        {
            Result<PaginatedList<Guest>> result = await _guestService.GetAllGuests(contract);

            return result.ToHttpResponseWithReasonError(() => Ok(new GetAllGuestsContractResponse()
            {
                list = result.Value.Select(s => new GetGuestContractResponse()
                {
                    id = s.Id,
                    wedding_id = s.WeddingId,
                    first_name = s.FirstName,
                    last_name = s.LastName,
                    email = s.Email,
                    phoneNumber = s.PhoneNumber,
                    attendance = s.Attendance,
                    has_allergies = s.HasAllergies,
                    allergies = s.Allergies,
                    diabetic = s.Diabetic,
                    celiac = s.Celiac,
                    vegan = s.Vegan,
                    vegetarian = s.Vegetarian,
                    message = s.Message
                }).ToList(),
                page_index = result.Value.PageIndex,
                page_size = result.Value.PageSize,
                total_pages = result.Value.TotalPages,
                total_records = result.Value.TotalRecords,
            }), (errors) => StatusCode(StatusCodes.Status400BadRequest, new BadRequest400ErrorProblemDetails(errors)));
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

