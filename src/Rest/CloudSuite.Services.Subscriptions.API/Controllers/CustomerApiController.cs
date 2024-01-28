using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Subscriptions.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerApiController : ControllerBase
	{
		// GET: api/<CustomerApiController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<CustomerApiController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CustomerApiController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CustomerApiController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CustomerApiController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
