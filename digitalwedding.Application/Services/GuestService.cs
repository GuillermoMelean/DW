using System;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Gateway.Guests;
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
            var ola = _guestRepository.GetAll();
            return Result.Ok(new CreateGuestResponse() { result = createGuestRequest.WeddingId });
        }
    }
}

