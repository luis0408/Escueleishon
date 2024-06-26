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

            response.Entity.Add(await new StudentData().getStudent());

            response.Code = "200";
            response.Message = "Success";

            return response;
        }

        public async Task<ResponseModel> addStudent(string noControl, string idCarrera, string idSemestre,
                                                string idGenero, string nombre, string apellidoPaterno,
                                                string apellidoMaterno, string edad, string CURP
                                                , string email, string telefono, string fechaNac, string estatus)
        {
            var response=new ResponseModel();
            var studenData = new StudentData();   
            var dtResponse= await studenData.addStudent(noControl,idCarrera,idSemestre,idGenero,nombre,apellidoPaterno,apellidoMaterno
                                                  ,edad,CURP,email,telefono,fechaNac,estatus);
            if (dtResponse.Rows.Count > 0)
            {
                var message = dtResponse.Rows[0]["message"].ToString();
                var code = dtResponse.Rows[0]["code"].ToString();

                response.Message = message;
                response.Code = code;

                if (code == "200")
                {
                    response.Entity.Add(await new StudentData().getStudent());

                }
            }
            else 
            {
                response.Message = "Ha ocurrido un error";
                response.Code = "500";
            }
            return response;
        }
    }
}
