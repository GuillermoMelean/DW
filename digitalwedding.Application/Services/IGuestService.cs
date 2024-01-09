using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Contracts;
using digitalwedding.Contracts.GuestContracts;
using Results;

namespace digitalwedding.Application.Services
{
    public interface IGuestService
	{
		Task<Result<CreateGuestResponse>> CreateGuest(CreateGuestRequest createGuestRequest);
		Task<Result<PaginatedList<Guest>>> GetAllGuests(GetAllGuestsContractRequest contract);
		Task<Result<Guest>> GetGuest(string id);
    }
}

