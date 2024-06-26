using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace Escueleishon.Server.Data
{
    public class StudentData
    {

        //public DataTable getCarrers()
        //{
        //    return null;
        //}

        public async Task<DataTable> getCarrers()
        {
            var dt = new DataTable();
            using (SqlCommand cmd= new SqlCommand("SP_CA_GetCarrers", dataConection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;


                cmd.Connection.Open();
                
                SqlDataReader dr= await cmd.ExecuteReaderAsync();
                dt.Load(dr);
                dr.Close();
                cmd.Connection.Close();
            }
            return dt;
        }
        public async Task<DataTable> getSemester()
        {
            var dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SP_CA_GetSemesters", dataConection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;


                cmd.Connection.Open();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                dt.Load(dr);
                dr.Close();
                cmd.Connection.Close();
            }
            return dt;
        }
        public async Task<DataTable> getGender()
        {
            var dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SP_CA_GetGenders", dataConection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;


                cmd.Connection.Open();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                dt.Load(dr);
                dr.Close();
                cmd.Connection.Close();
            }
            return dt;
        }
        public async Task<DataTable> addStudent(string noControl,string idCarrera, string idSemestre,
                                                string idGenero, string nombre,string apellidoPaterno,
                                                string apellidoMaterno, string edad, string CURP
                                                ,string email, string telefono, string fechaNac,string estatus)
        {
            var dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SP_CA_AddStudent", dataConection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@noControl",noControl);
                cmd.Parameters.AddWithValue("@idCarrera", idCarrera);
                cmd.Parameters.AddWithValue("@idSemestre", idSemestre);
                cmd.Parameters.AddWithValue("@idGenero", idGenero);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@CURP", CURP);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@estatus", estatus);


                cmd.Connection.Open();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                dt.Load(dr);
                dr.Close();
                cmd.Connection.Close();
            }
            return dt;
        }
        private SqlConnection dataConection()
        {
            return new SqlConnection(@"server=DESKTOP-IRHIAA8\LRSERVER;initial catalog=Escueleishon;Integrated Security=True;TrustServerCertificate=true");
        }
        public async Task<DataTable> getStudent()
        {
            var dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SP_CA_GetStudents", dataConection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Connection.Open();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                dt.Load(dr);
                dr.Close();
                cmd.Connection.Close();
            }
            return dt;
        }
    }
}
