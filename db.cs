sing System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace MSSQL1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True
 
            //Command and Data Reader
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(
                @"Server=tcp:itaydb.database.windows.net,1433;Initial Catalog=edb;Persist Security Info=False;User ID=itaydb;Password=Password1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //@"Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Employees";
 
 
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
 
            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($" {reader["ID"]} {reader["FIRSTNAME"]} {reader["LASTNAME"]} {reader["SALARY"]}");
                var e = new
                {
                    Id = reader["ID"],
                    firaName = reader["FIRSTNAME"]
                };
                list.Add(e);
            }
 
            cmd.Connection.Close();
        }
    }
}
