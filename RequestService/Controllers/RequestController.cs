using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestController.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        //GET api/request
        [HttpGet]
        public async Task<ActionResult> MakeResquest()
        {

            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("");

            //  var response = await _clientePolicy.ImmediateHttpretry.ExecuteAsync(() => client.GetAsync(""));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService returned SUCCESS");
                return Ok();

            }

            Console.WriteLine("--> ResponseService returned FAILURE");
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }
}