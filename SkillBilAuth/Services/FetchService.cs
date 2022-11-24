using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace SkillBilAuth.Services
{
    public static class FetchService
    {
        private static readonly string connectionString = "Data Source=SQLSERVER;Initial Catalog=SkillBill;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=********";
        public static SqlConnection con;
        public static void CreateTheConnection()
        {
            try
            {
                con = new SqlConnection(connectionString);
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
