using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ADODisconnected.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public void Accept()
    {
        WriteLine("Enter Id Name  & Price");
        Id = int.Parse(ReadLine());
        Name = ReadLine();
        Price = double.Parse(ReadLine());
    }
    public override string ToString()
    {
        return $"Id:{Id} Name:{Name} Price: {Price}";
    }
}
