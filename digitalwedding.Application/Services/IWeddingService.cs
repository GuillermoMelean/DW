using System;
using digitalwedding.Application.Data.Models.Gateway.Guests;
using digitalwedding.Application.Data.Models.Gateway.Wedding;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Contracts;
using digitalwedding.Contracts.WeddingContracts;
using Results;

namespace digitalwedding.Application.Services
{
	public interface IWeddingService
	{
        Task<Result<GetWeddingResponse>> GetWedding(string Id);
        Task<Result<List<GetWeddingResponse>>> GetAllWeddings();
        Task<Result<PaginatedList<Wedding>>> GetAllWeddings(GetAllWeddingsContractRequest contract);
    }
}

