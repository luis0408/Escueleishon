using System.Data;
using System.Data.SqlClient;

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
            using (SqlCommand cmd= new SqlCommand("SP_CA_GetCarrers", new SqlConnection(@"server=DESKTOP-IRHIAA8\LRSERVER;initial catalog=Escueleishon;Integrated Security=True;TrustServerCertificate=true")))
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
            using (SqlCommand cmd = new SqlCommand("SP_CA_GetSemesters", new SqlConnection(@"server=DESKTOP-IRHIAA8\LRSERVER;initial catalog=Escueleishon;Integrated Security=True;TrustServerCertificate=true")))
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
            using (SqlCommand cmd = new SqlCommand("SP_CA_GetGenders", new SqlConnection(@"server=DESKTOP-IRHIAA8\LRSERVER;initial catalog=Escueleishon;Integrated Security=True;TrustServerCertificate=true")))
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
    }
}
