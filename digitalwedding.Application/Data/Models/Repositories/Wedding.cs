namespace digitalwedding.Application.Data.Models.Repositories
{
	public class Wedding: Base
	{
        public required string UserId { get; set; }
        public DateTime WeddingDate { get; set; }
        public int WeddingStatusId { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string Url { get; set; }
    }
}

