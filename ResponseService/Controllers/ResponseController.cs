using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class ResponseService : ControllerBase
    {
        //GET /api/response/100
        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetAResponse(int id)
        {

            Random rnd = new Random();
            var rndInteger = rnd.Next(1, 101);

            if (rndInteger >= id)
            {
                Console.WriteLine("--> Failure - Generata a HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Success - Generata a HTTP 200");


            return Ok();
        }
    }
}