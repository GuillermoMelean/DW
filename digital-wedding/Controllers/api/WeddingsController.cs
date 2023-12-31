using Microsoft.AspNetCore.Mvc;

namespace digital_wedding.Controllers.api
{
    [ApiController]
    [Route("api/weddings")]
    public class WeddingController: ControllerBase
	{
        [HttpGet("{id}")]
        public IActionResult GetWedding(string id)
		{
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }



            return Ok(id);
        }
	}
}

