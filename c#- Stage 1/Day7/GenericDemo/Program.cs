namespace GenericDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item(5);
            //Object m = new Model();    //base class hold reference of child class.
            //Object[] arr = { m, item, "hello" };   //heterogeneous array

            //Model <int> m = new Model<int>();
            Model<int> mod = new();
            mod.Func1(3);
            mod.Id = 1;
        }
    }
}