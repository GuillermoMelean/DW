using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Application.Errors;
using digitalwedding.Application.Extensions;
using digitalwedding.Contracts;
using digitalwedding.Contracts.GuestContracts;
using Microsoft.Extensions.Logging;
using Results;

namespace digitalwedding.Application.Services
{
	public class GuestService: IGuestService
	{
        public readonly ILogger<GuestService> _logger;
        protected readonly IWeddingRepository _weddingRepository;
        protected readonly IGuestRepository _guestRepository;

		public GuestService(ILogger<GuestService> logger,
            IWeddingRepository weddingRepository,
            IGuestRepository guestRepository
            )
		{
            _logger = logger;
            _weddingRepository = weddingRepository;
            _guestRepository = guestRepository;
		}

        public async Task<Result<CreateGuestResponse>> CreateGuest(CreateGuestRequest createGuestRequest)
        {
            return Result.Ok(new CreateGuestResponse() { result = createGuestRequest.WeddingId });
        }

        public async Task<Result<PaginatedList<Guest>>> GetAllGuests(GetAllGuestsRequest getAllGuestsRequest)
        {
            try
            {
                Expression<Func<Guest, bool>> expression = whitelisteduser => true;

                if (!string.IsNullOrWhiteSpace(getAllGuestsRequest.wedding_id))
                {
                    expression = expression.Combine(s => s.WeddingId.Equals(getAllGuestsRequest.wedding_id), Expression.Parameter(typeof(Guest), "weddingId"));
                }

                PaginatedList<Guest> result = await _guestRepository.GetGuests(expression, getAllGuestsRequest.page_index, getAllGuestsRequest.page_size);
                return Result.Ok(result);

            }
            catch (Exception ex)
            {
                return Result.Fail(new DatabaseError().CausedBy(ex));
            }
        }

        public async Task<Result<PaginatedList<Guest>>> GetAllGuests(GetAllGuestsContractRequest contract)
        {
            try
            {
                Expression<Func<Guest, bool>> expression = whitelisteduser => true;

                if (!string.IsNullOrWhiteSpace(contract.wedding_id))
                {
                    expression = expression.Combine(s => s.WeddingId.Equals(contract.wedding_id), Expression.Parameter(typeof(Guest), "weddingId"));
                }

                PaginatedList<Guest> result = await _guestRepository.GetGuests(expression, contract.page_index, contract.page_size);

                return Result.Ok(result);

            }
            catch (Exception ex)
            {
                return Result.Fail(new DatabaseError().CausedBy(ex));
            }
        }

        public async Task<Result<Guest>> GetGuest(string id)
        {
            try
            {
                Guest result = await _guestRepository.GetByIdAsync(id);

                if (result == null)
                {
                    return Result.Fail(new NotFoundError("Guest Not Found"));
                }

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail(new DatabaseError().CausedBy(ex));
            }
        }
    }
}

