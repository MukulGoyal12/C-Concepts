namespace RealEstate{
    internal class Program{
        static void Main (string[]args){
           Property p;//reference type
           //if i use datatype to declare like int a= then that is value type variable not reference type.
           p= new Property();//operator-> reference variable //creates instance in heap
           //instances are in heap memory and referenace are in stack memory. Reference -4 byte always
           p.Accept();
           p.Display();
        }
    }
}