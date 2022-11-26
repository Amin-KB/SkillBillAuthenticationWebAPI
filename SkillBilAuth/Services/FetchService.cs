using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace SkillBilAuth.Services
{
    public static class FetchService
    {
        
        public static SqlConnection con;
        public static void CreateTheConnection()
        {
            try
            {
                con = new SqlConnection(ConfigurationService.connectionString);
                con.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static int? GetUserRole(int id)
        {
            string sql = $"SELECT dbo.fn_GetRole('{id}') AS RoleId";
            //con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int? RoleId =Convert.ToInt32(rdr["RoleId"]);

                return RoleId;
            }
            return null;
        }
      
    }
}
