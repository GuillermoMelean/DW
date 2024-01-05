using System;
namespace digitalwedding.Application.Data.Models.Gateway.Guests
{
	public class CreateGuestRequest
	{
		public required string WeddingId { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public string? PhoneNumber { get; set; }
		public bool Attendance { get; set; }
		public bool HasAllergies { get; set; }
		public string? Allergies { get; set; }
		public bool Diabetic { get; set; }
		public bool Celiac { get; set; }
		public bool Vegan { get; set; }
		public bool Vegetarian { get; set; }
		public string? Message { get; set; }
	}
}

