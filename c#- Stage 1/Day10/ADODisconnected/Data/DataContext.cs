using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using ADODisconnected.Model;
namespace ADODisconnected.Data
{
    internal class DataContext
    {
        static DataSet ds = new();
        static SqlDataAdapter adapter;
        static SqlCommandBuilder builder;
        static DataTable dt;//creating a reference variable for datatable
        static readonly string connstring = @"server=.\sqlexpress;initial catalog=cognizant;integrated security=true;trustservercertificate=true";
        static DataContext()
        {
            adapter = new SqlDataAdapter("select * from products", connstring);
            adapter.Fill(ds);//builder pattern
            builder = new SqlCommandBuilder(adapter);
            dt = ds.Tables[0];//setting dt with address of datatable object stored in table[0]
                              //so now onwards you can use dt instead of ds.Tables[0]
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };     //setting primary key in the
                                                                    //datatable(needed for update and delete operation)
        }

        public void ShowProducts()
        {
            foreach (var c in ds.Tables[0].Columns) //displaying column heading
            {
                Console.Write(c.ToString() + "\t");
            }
            
            Console.WriteLine();
            //foreach(DataRow dr in dt.Rows)//iterating through rows

            foreach (DataRow dr in dt.Select(null, null, DataViewRowState.CurrentRows))//skipping deleted rows in datatable
            {
                {
                    foreach (var dc in dr.ItemArray)//iterating through each column in the row
                    {
                        Console.Write(dc?.ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddProduct(Product p)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = p.Id; dr[1] = p.Name;
            dr[2] = p.Price;
            ds.Tables[0].Rows.Add(dr);
        }
        public void UpdateProduct(int id, double newprice)
        {
            DataRow? dr = dt.Rows.Find(id);
            if (dr != null)
                dr["price"] = newprice;
        }
        public void DeleteProduct(int id)
        {
            DataRow? dr = dt.Rows.Find(id);
            dr?.Delete();// ? operator ensure that delete method called only
                         //if dr is not null(i.e Find() returns a row)  
        }
        public void Save()
        {
            adapter.Update(ds);
        }
    }

}
