using System;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using Results;

namespace digitalwedding.Application.Services
{
	public interface IGuestService
	{
		Task<Result<CreateGuestResponse>> CreateGuest(CreateGuestRequest createGuestRequest);
	}
}

