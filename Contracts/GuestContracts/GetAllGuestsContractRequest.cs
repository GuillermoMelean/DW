using System;
namespace digitalwedding.Contracts.GuestContracts
{
	public class GetAllGuestsContractRequest
	{
		public string? wedding_id { get; set; }
		public int page_index { get; set; } = 1;
		public int page_size { get; set; } = 20;
	}
}

