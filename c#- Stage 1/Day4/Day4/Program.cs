using System.Text;

class Program
{

    public static void Main(string[] args)
    {
        int n; //Int 32 
        string s = "hello";           // == String s = new String("hello")
        Object a = 12;               //Auto Boxing means ye int string object ye sb c# me datatypes nahi class hote hai.
                                    //And hme dekhne or to lagta h ki hmne variable banaya h but hmne object bnaya hota h to
                                   //vo hmari value ko directly assign kr deta h object me , use bolte h auto boxing.
        Console.WriteLine(a);     //Auto unboxing , here what happen is a me address
                                 //store hai but vo value de rha h kyuki a.ToString()
                                //call hai peeche se.
        Student st = new Student();
        st.Id = 10;
        st.Name = s;
        Console.WriteLine(st);                        //idhr ToString() ko override krke hmne Auto Bpxing krdi.
                                                     //Nahi krte to error deta
        Console.WriteLine("mukul".ToUpper());       // new String("mukul").ToUpper().ToString()
                                                   // String pool me mukul ki string bani or phir uppercase
                                                  // ki new string bani. islie string immutable hoti h.
                                                 // "mukul.ToUpper" and "MUKUL" name ki do string bani string pool me but mene kisi
                                                // variable me store hi nahi kia too me bad me use hi nahi kr skta islie ye orphan kehlaenge.
        

        StringBuilder sb= new StringBuilder();            //Mutable string
        sb.Append(s);
        Console.WriteLine(sb.ToString());
        string mssg = sb + " cognizant";
        Console.WriteLine(mssg);

        Days Birthday = Days.Tuesday;
        int Bday = (int)Days.Tuesday;
        Console.WriteLine(Birthday);
        Console.WriteLine(Bday);
        // if(Birthday is Days.Tuesday)
        // {
        //     Console.WriteLine("Ghar jao koi bday nahi banega.");
        // }
    }
}

enum Days { Sunday=5 , Monday=3 , Tuesday=10}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} Name: {Name}";
    }
}