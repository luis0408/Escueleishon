using Escueleishon.Server.Data;
using Escueleishon.Server.Models;
using System.Data;

namespace Escueleishon.Server.Process
{
    public class StudentProcess
    {

        public async Task<ResponseModel> getCatalogs()
        {
            var response= new ResponseModel();  

            var dt= await new StudentData().getCarrers();
            var dtSemesters = await new StudentData().getSemester();
            var dtGender = await new StudentData().getGender();

            response.Entity.Add(dt);
            response.Entity.Add(dtSemesters);
            response.Entity.Add(dtGender);

            response.Code = "200";
            response.Message = "Success";

            return response;
        }
    }
}
