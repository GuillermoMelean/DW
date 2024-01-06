using System;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Data.Models.Gateway.Wedding;
using Results;

namespace digitalwedding.Application.Services
{
	public interface IWeddingService
	{
        Task<Result<GetWeddingResponse>> GetWedding(string Id);
    }
}

