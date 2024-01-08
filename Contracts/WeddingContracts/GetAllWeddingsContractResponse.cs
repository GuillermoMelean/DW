namespace digitalwedding.Contracts.WeddingContracts
{

    public class GetAllWeddingsContractResponse
    {
        public List<GetWeddingContractResponse> list { get; set; }
        public int page_size { get; set; }
        public int page_index { get; set; }
        public int total_pages { get; set; }
        public int total_records { get; set; }
    }
}

