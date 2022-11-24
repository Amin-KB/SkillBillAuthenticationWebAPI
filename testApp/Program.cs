// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;

var sqlConnection = new SqlConnection("Data Source=AMIN-PC\\SQLEXPRESS;Initial Catalog=SkillBill;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=33509110Karaj");
string sql = $"SELECT * FROM AspNetUsers WHERE Email= 'Ad.Min@qualifizierung.at'";
string sql2 = $"SELECT dbo.fn_GetRole('ITN069538@qualifizierung.at') AS RoleId";
sqlConnection.Open();
//SqlCommand cmd = new SqlCommand(sql, sqlConnection);
SqlCommand cmd2 = new SqlCommand(sql2, sqlConnection);
//SqlDataReader rdr = cmd.ExecuteReader();
SqlDataReader rdr2 = cmd2.ExecuteReader();

//while (rdr.Read())
//{
//    int id = Convert.ToInt32(rdr["Id"]);
//    Console.WriteLine(id);
    
//}
while (rdr2.Read())
{
    int id = Convert.ToInt32(rdr2["RoleId"]);
    Console.WriteLine(id);

}
//GetUserRole("Ad.Min@qualifizierung.at");
//public static int? GetUserRole(string email)
//{
//    string sql = $"SELECT dbo.fn_GetRole('{email}') AS RoleId";
//    //con.Open();
//    SqlCommand cmd = new SqlCommand(sql, con);
//    SqlDataReader rdr = cmd.ExecuteReader();
//    while (rdr.Read())
//    {
//        int id = Convert.ToInt32(rdr["RoleId"]);

//        return id;
//    }
//    return null;
//}

