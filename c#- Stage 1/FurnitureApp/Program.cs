using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1.Chair 2.Shelves 3.Exit");
        int choices = int.Parse(Console.ReadLine());
        Furniture f=null;
        switch (choices)
        {
            case 1:
                f= new Chair();
                break;
            case 2:
                f= new Shelves();
                break;
            case 3:
            Console.WriteLine("Thank You. Kuch lena nahi hota to aya bhi mt kia kro");
                break;
            default:
            Console.WriteLine("Bhai shi dal le");
                break;
        }
        f.Accept();  // dynamic binding by using virtual in furniture and override in shelves and chair. mtlb pehle kya ho rha tha f furniture ka refrence variable haina to seedhe furniture ke accept ko chala rha tha but ye krne ke bad chair or shelves ke accept or display ko chalane laga.
        f.Display();
    }
}