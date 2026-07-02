namespace SealedDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    //sealed classes,sealed functions
     class Items{
        public int ItemId { get; set; }
        public virtual void Accept()
        {

        }
    }
    class Models : Items
    {
        public sealed override void Accept()
        {
                
        }
    }
    class ThirdClass : Models {
        public  void Accept() { }
         
    }
}
