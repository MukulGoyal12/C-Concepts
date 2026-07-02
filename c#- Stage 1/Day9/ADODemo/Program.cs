using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;
namespace AdoConnectedDemo

{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = null;
            try
            {
                string connstring = @"server=.\sqlexpress;initial catalog=cognizant;integrated security=true;trustservercertificate=true;";
                connection = new SqlConnection(connstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into products values(2,'lays',22)";
                connection.Open();
                cmd.ExecuteNonQuery();  //for dml 


                //In case DML
                //cmd.CommandText = "select * from products";
                //reader = cmd.ExecuteReader();
                //while (reader.read())                   //ref is before first row and read() moves it to next row and it return boolean
                //{
                    //Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                //}
            }
            catch (SqlException e) { Console.WriteLine(e.ToString()); }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}

