using System;
namespace digitalwedding.Contracts.GuestContracts
{
	public class GetGuestContractResponse
	{
        public required string id { get; set; }
        public required string wedding_id { get; set; }
        public required string first_name { get; set; }
        public required string last_name { get; set; }
        public required string email { get; set; }
        public string? phone_number { get; set; }
        public required bool attendance { get; set; }
        public required bool has_allergies { get; set; }
        public string? allergies { get; set; }
        public required bool diabetic { get; set; }
        public required bool celiac { get; set; }
        public required bool vegan { get; set; }
        public required bool vegetarian { get; set; }
        public string? message { get; set; }
    }
}

