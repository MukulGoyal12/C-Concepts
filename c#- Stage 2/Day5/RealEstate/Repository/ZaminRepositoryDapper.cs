using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using RealEstate.Models;

namespace RealEstate.Repository
{
    public class ZaminRepositoryDapper : IZaminRepository
    {
        IDbConnection database;
        static string connstring = @"server=.\sqlexpress;initial catalog=cognizant;integrated security=true; trustservercertificate=true";

        public ZaminRepositoryDapper()
        {
            database = new SqlConnection(connstring);
        }

        public bool AddZamin(Zamin z)
        {
            // Note: Parameterized query use karna behtar hai security ke liye
            string insertquery = "insert into zamin values(1,'Aditya Complex',4000,'Yeshwanthpur')";
            database.Execute(insertquery);
            return true;
        }

        public bool DeleteZamin(int id)
        {
            string deleteQuery = "Delete from Zamin where id=@id";
            int rowsDeleted = database.Execute(deleteQuery, id);
            Console.WriteLine($"{rowsDeleted} row(s) deleted.");
            return rowsDeleted > 1 ? true : false;
        }

        public List<Zamin> GetAllZamin()
        {
            string SelectQuery = "Select * from zamin";


        }

        public Zamin GetZamin(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateZamin()
        {
            throw new NotImplementedException();
        }
    }
}