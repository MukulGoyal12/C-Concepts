namespace InterfaceTopDownApproach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flat f = new Flat();  
            //f.Accept();               //will fail in case implicit method.
            ((Building)f).Accept();    //This is how we call explicit method
            Building b = new Flat();
            b.Display();   //chal jaega
            //f.Display();   //Nahi chalega kyuki abhi tk override nahi kia , inherit ho hi nahi skta , but override kr dia to chal jaega.
            f.Display();
            b.Increment();  // will call but not f.inc... bcoz no inheritance
        }
    }
}
