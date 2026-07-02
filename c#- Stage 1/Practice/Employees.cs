internal struct Employee       // class ki jgh struct, no change
{
    public int Code;
    public string Name;

    public void Display()
    {
        Console.WriteLine($"Code:{Code} Name:{Name}");
    }
}

// record struct Product(int Id, string Name, float Price);
record Product(int Id, string Name, float Price);

// This is equal to |
//                  V

// class Product{
// 	public int Id{get;init;}
// 	public string Name{get;init;}       //At instance variable we can initialize value and only access but can't reinitialize
// 	public float Price{get;init;}

//     public Product(int id, string name , float price)
//     {
//         Id=id;
//         Name=name;
//         Price=price;
//     }
// }

class Products(int Id, string Name, float Price)
{
    public void Display()                // fields are private in class so we can not access directlty
    {
        Console.WriteLine(Id);
        Console.WriteLine(Name);
        Console.WriteLine(Price);
    }
}    //allow in 8+ version

// This is equal to |
//                  V

// class Product{
// 	private int Id{get;init;}
// 	private string Name{get;init;}     
// 	private float Price{get;init;}

//     public Product(int id, string name , float price)
//     {
//         Id=id;
//         Name=name;
//         Price=price;
//     }
// }