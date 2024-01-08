using System;
using System.Linq.Expressions;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Gateway.Wedding;
using digitalwedding.Application.Data.Models.Repositories;
using digitalwedding.Application.Errors;
using digitalwedding.Application.Extensions;
using digitalwedding.Contracts;
using digitalwedding.Contracts.WeddingContracts;
using Microsoft.Extensions.Logging;
using Results;

namespace digitalwedding.Application.Services
{
    public class WeddingService : IWeddingService
    {
        public readonly ILogger<WeddingService> _logger;
        protected readonly IWeddingRepository _weddingRepository;

        public WeddingService(
            ILogger<WeddingService> logger,
            IWeddingRepository weddingRepository)
        {
            _logger = logger;
            _weddingRepository = weddingRepository;
        }

        public async Task<Result<GetWeddingResponse>> GetWedding(string Id)
        {
            var response = await _weddingRepository.GetByIdAsync(Id);

            if(response != null)
            {
                return Result.Ok(new GetWeddingResponse()
                {
                    id = response.Id,
                    first_name = response.FirstName,
                    second_name = response.SecondName,
                    url = response.Url,
                    wedding_date = response.WeddingDate
                });
            }

            return Result.Fail(new Error("Wedding Not Found"));
        }

        public async Task<Result<List<GetWeddingResponse>>> GetAllWeddings()
        {
            var response = _weddingRepository.GetAll().ToList();

            if (response != null)
            {
                var oi = response.Select(w => new GetWeddingResponse()
                {
                    id = w.Id,
                    first_name = w.FirstName,
                    second_name = w.SecondName,
                    url = w.Url,
                    wedding_date = w.WeddingDate
                }).ToList();

                return Result.Ok(oi);
            }

            return Result.Fail(new Error("Wedding Not Found"));
        }

        public async Task<Result<PaginatedList<Wedding>>> GetAllWeddings(GetAllWeddingsContractRequest contract)
        {
            try
            {
                Expression<Func<Wedding, bool>> expression = whitelisteduser => true;

                //if (!string.IsNullOrWhiteSpace(contract.username))
                //{
                //    expression = expression.Combine(s => s.Username.Equals(contract.username), Expression.Parameter(typeof(Wedding), "username"));
                //}
                //if (!string.IsNullOrWhiteSpace(contract.client_id))
                //{
                //    expression = expression.Combine(s => s.ClientId.Equals(contract.client_id), Expression.Parameter(typeof(Wedding), "client_id"));
                //}

                PaginatedList<Wedding> result = await _weddingRepository.GetWeddings(expression, contract.page_index, contract.page_size);

                return Result.Ok(result);

            }
            catch (Exception ex)
            {
                return Result.Fail(new DatabaseError().CausedBy(ex));
            }
        }
    }
}

