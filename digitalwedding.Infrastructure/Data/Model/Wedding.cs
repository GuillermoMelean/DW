using System;
namespace digitalwedding.Infrastructure.Model
{
	public class Wedding
	{
		public string Id { get; set; }
		public string userId { get; set; }
		public DateTime weddingDate { get; set; }
		public int weddingStatusId { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string url { get; set; }
		public DateTime createdAt { get; set; }
		public DateTime updatedAt { get; set; }

	}
}

