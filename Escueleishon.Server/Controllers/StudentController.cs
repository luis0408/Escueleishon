using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Escueleishon.Server.Process;
using System.Text.Json;
using System.Net.NetworkInformation;

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

        [Route("addStudent")]
        [HttpPost]
        public async Task<ActionResult> addStudent([FromBody] JsonElement element)
        {
            
            var noControl=element.GetProperty("noControl").ToString();
            var idCarrera=element.GetProperty("idCarrera").ToString();
            var idSemestre=element.GetProperty("idSemestre").ToString();
            var idGenero=element.GetProperty("idGenero").ToString();
            var nombre=element.GetProperty("nombre").ToString();
            var apellidoPaterno=element.GetProperty("apellidoPaterno").ToString();
            var apellidoMaterno=element.GetProperty("apellidoMaterno").ToString();
            var edad=element.GetProperty("edad").ToString();
            var CURP=element.GetProperty("CURP").ToString();
            var email=element.GetProperty("email").ToString();
            var telefono=element.GetProperty("telefono").ToString();
            var fechaNac=element.GetProperty("fechaNac").ToString();
            var estatus=element.GetProperty("estatus").ToString();

            var response = await new StudentProcess().addStudent(noControl,idCarrera,idSemestre,idGenero,nombre,apellidoPaterno,apellidoMaterno
                                                                 ,edad,CURP,email,telefono,fechaNac,estatus );
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
