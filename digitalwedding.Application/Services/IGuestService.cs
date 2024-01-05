using System;
using digitalwedding.Application.Data.Models.Gateway.Guests;

namespace digitalwedding.Application.Services
{
	public interface IGuestService
	{
		Task<CreateGuestResponse> CreateGuest(CreateGuestRequest createGuestRequest);
	}
}

