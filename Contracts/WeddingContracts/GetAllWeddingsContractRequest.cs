using System;
namespace digitalwedding.Contracts.WeddingContracts
{
	public class GetAllWeddingsContractRequest
	{
        public int page_index { get; set; } = 1;
        public int page_size { get; set; } = 20;
    }
}

