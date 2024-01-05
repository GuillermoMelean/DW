using System;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using Microsoft.Extensions.Logging;

namespace digitalwedding.Application.Services
{
	public class GuestService: IGuestService
	{
        public readonly ILogger<GuestService> _logger;

		public GuestService(ILogger<GuestService> logger)
		{
            _logger = logger;
		}

        public Task<CreateGuestResponse> CreateGuest(CreateGuestRequest createGuestRequest)
        {

            return Task.FromResult(new CreateGuestResponse() { result = createGuestRequest.WeddingId});
        }
    }
}

