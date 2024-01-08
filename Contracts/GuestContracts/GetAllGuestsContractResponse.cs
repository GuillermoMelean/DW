namespace digitalwedding.Contracts.GuestContracts
{
	public class GetAllGuestsContractResponse
	{
        public List<GetGuestContractResponse> list { get; set; }
        public int page_size { get; set; }
        public int page_index { get; set; }
        public int total_pages { get; set; }
        public int total_records { get; set; }
    }
}

