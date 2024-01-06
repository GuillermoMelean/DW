using System;
using digitalwedding.Application.Data.Interfaces;
using digitalwedding.Application.Data.Models.Gateway.Wedding;
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

            return Result.Ok(new GetWeddingResponse()
            {
                id = response.Id,
                first_name = response.firstName,
                second_name = response.secondName,
                url = response.url,
                wedding_date = response.weddingDate
            });
        }
    }
}

