using System;
namespace digitalwedding.Application.Data.Models.Repositories
{
	public class Wedding: Base
	{
        public string Id { get; set; }
        public string userId { get; set; }
        public DateTime weddingDate { get; set; }
        public int weddingStatusId { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string url { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}

