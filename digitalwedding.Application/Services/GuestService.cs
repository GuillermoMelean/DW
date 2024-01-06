using System;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using Microsoft.Extensions.Logging;

namespace digitalwedding.Application.Services
{
	public class GuestService: IGuestService
	{
        public readonly ILogger<GuestService> _logger;
        protected readonly IWeddingRepository _weddingRepository;

		public GuestService(ILogger<GuestService> logger,
            IWeddingRepository weddingRepository)
		{
            _logger = logger;
            _weddingRepository = weddingRepository;
		}

        public Task<CreateGuestResponse> CreateGuest(CreateGuestRequest createGuestRequest)
        {
            var ola = _weddingRepository.GetAll().ToList();
            return Task.FromResult(new CreateGuestResponse() { result = createGuestRequest.WeddingId});
        }
    }
}

