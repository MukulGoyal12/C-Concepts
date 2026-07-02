namespace InBuiltDeligates
{
    delegate double Mydelegate(double bal);   //custom delegate type

    internal class Program
    {
        static void Main(string[] args)
        {
            //Mydelegate m = (bal) => { return 0.0; };
            Func<int, int, int> f = (a, b) => { Console.WriteLine(a + b); return 10; };    //Means 2 parameter int and return type is int
            f(4, 4);
            Func<double, double> m = MyFunc;
            m(5);
            Func<string> s = delegate () { return "helo"; };   //No parameter but return type is string.
            Console.WriteLine(s());
            //Func<> newFunc = delegate () { Console.WriteLine("Hello World"); }     Not passed because func ko atleast ek return type chahie hi chahie,
            //Console.WriteLine(newFunc());                                          Agar return type nahi dena to action use kro.

            // For void , not return type and no parameter
            Action action1 = () => { Console.WriteLine("SomeFunc"); };

            // For void , no return type 
            Action<string> action = SomeFunc;
            action += (mssg) => { Console.WriteLine(mssg.ToUpper()); };  //muticast delegate, an action delegate can contain adress of multiple functions
            action -= SomeFunc;   //hta dega somefunc ko
            action.Invoke("This is testing.");
            action("mukul");

            //predicate means return type boolean hona chahie.
            Predicate<int> predicate = (int param1) => {return true; };
        }

        static double MyFunc(double p) {  return p; }
        static void SomeFunc(string hi) { Console.WriteLine("SomeFunc"); }
    }
}