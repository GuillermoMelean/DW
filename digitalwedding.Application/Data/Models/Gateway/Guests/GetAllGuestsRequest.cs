using System;
namespace digitalwedding.Application.Data.Models.Gateway.Guests
{
	public class GetAllGuestsRequest
	{
		public string wedding_id { get; set; }
		public int page_index { get; set; } = 1;
		public int page_size { get; set; } = 20;
	}
}

