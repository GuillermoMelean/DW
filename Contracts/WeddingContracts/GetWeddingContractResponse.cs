using System;
namespace digitalwedding.Contracts.WeddingContracts
{
	public class GetWeddingContractResponse
	{
        public string id { get; set; }
        public DateTime wedding_date { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string url { get; set; }
    }
}

