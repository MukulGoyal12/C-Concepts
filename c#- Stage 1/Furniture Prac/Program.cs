internal class Program
{
    static void Main(string []args)
    {
        // Furniture f= new Furniture();
        // f.Id=7;
        // f.Count=999;

        //destructuring
        (int, string , float) data = (1,"hello",3.3f);
        (int a, string b, float c)=data;

        var tuple1= (4,"hello");    //var is use to make tuple. TYPE INFERENCING

        var age=30;  // type of age int apne app infer ho jaegi
        // age="mukul";  error dega kyuki ek baar assign ho gya vhi rhega

        dynamic var1 = 50;
        var1="mukul";  //no error bcoz dynamic me ho skta h

        Program p = new Program();

        p.Add(2,3,out int res);   // declare res var of out int type
        Console.WriteLine(res);
        p.Add(2,33,out _);  //ignore return value; DISCARD OPERATOR 

        (int,float) sumAvg=p.SumAvg(10,20,40);    //tuple type variable
        Console.WriteLine(sumAvg);
        Console.WriteLine(sumAvg.Item1);
        Console.WriteLine(sumAvg.Item2);
        (int sum,float avg)=p.SumAvg(10,20,40);    //Destructuring
        Console.WriteLine($"sum {sum} and avg {avg}");
    }

    void Add(int x , int y, out int result)   // void hote hue bhi me return kar skta hu , out tyoe ki vjh se.
    {
        result = x+y;
    }

    (int,float) SumAvg(int a , int b ,int c)
    {
        return ((a+b+c),(float)(a+b+c)/3);
    }
}