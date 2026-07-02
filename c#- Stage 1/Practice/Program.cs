using System.Security.Authentication.ExtendedProtection;
 
//CALLBYVALUE
// namespace StringsDemo{
//     internal class Program
//     {
//         static void Main(String[] args)
//         {
//             int x=100,y=300;//when you call a function but only the value in passed not the variable- call by value;
//             Change(x,y);
//             Console.WriteLine($"x:{x} y:{y}");
//         }
//         static void Change(int a, int b)//local variables->change
//         {
//             int c=a;
//             a=b;
//             b=c;
//             Console.WriteLine($"a{a} b:{b}");
//         }
//     }
// }
 



//Here when employee is class its value is pass by reference but now I do it struct instead of class then its value is pass by value;
 
//VALUEBYREFERENCE
// namespace StringsDemo{
//     internal class Program
//     {
//         static void Main(String[] args)
//         {
//             int x=100,y=300;//when you call a function but only the value in passed not the variable- call by value;
//             Change(ref x,ref y);
//             Console.WriteLine($"x:{x} y:{y}");
//             Employee emp=new Employee{Code=100,Name="John"};
//             Console.WriteLine($"inside mainCode:{emp.Code} Name:{emp.Name}");
//             Change(emp);
//             Console.WriteLine($"inside main after change: Code:{emp.Code} Name:{emp.Name}");
//         }
//         static void Change( ref int a,ref int b)//local variables->change
//         {
//             int c=a;
//             a=b;
//             b=c;
//             Console.WriteLine($"a{a} b:{b}");
//         }
//         static void Change(Employee e)
//         {
//             e.Code=200;
//             e.Name="Cognizant";
//             Console.WriteLine($"code:{e.Code} Name:{e.Name}");
//         }
//     }
// }





//  but by using ref before Employee it works as Call By Reference. FOR STRUCT

// namespace StringsDemo{
//     internal class Program
//     {
//         static void Main(String[] args)
//         {
//             int x=100,y=300;//when you call a function but only the value in passed not the variable- call by value;
//             Change(ref x,ref y);
//             Console.WriteLine($"x:{x} y:{y}");

//             Employee emp;
//             emp.Code=100;
//             emp.Name="John";
//             emp.Display();
//             Change(ref emp);
//             emp.Display();
//         }
//         static void Change( ref int a,ref int b)//local variables->change
//         {
//             int c=a;
//             a=b;
//             b=c;
//             Console.WriteLine($"a{a} b:{b}");
//         }
//         static void Change(ref Employee e)
//         {
//             e.Code=200;
//             e.Name="Cognizant";
//             Console.WriteLine($"code:{e.Code} Name:{e.Name}");
//         }
//     }
// }




// FOR RECORD And CLASS

namespace StringsDemo{
    internal class Program
    {
        static void Main(String[] args)
        {
            //FOR RECORD IMPLICIT 
            
            Product p = new Product(1,"lays",44);
            Console.WriteLine(p.Id);
            // p.Id=22;    error because At instance variable we can initialize value and only access but can't reinitialize

            //FOR CLASS IMPLICIT 

            Products pp = new Products(1,"lays",44);
            pp.Display();
            // Console.WriteLine(pp.Id);
        }

    }
}