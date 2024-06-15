using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Escueleishon.Server.Process;

namespace Escueleishon.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        [Route("getCatalogs")]
        [HttpPost]
        public async Task<ActionResult> getCatalogs()
        {
            var response = await new StudentProcess().getCatalogs();
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
