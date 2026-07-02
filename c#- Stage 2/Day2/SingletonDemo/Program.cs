namespace SingletonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //More than one instace made means not singleton.
            //DatabaseConnection obj = new DatabaseConnection();
            DatabaseConnection obj1 = DatabaseConnection.GetInstance();
            DatabaseConnection obj2 = DatabaseConnection.GetInstance();
            obj1.Open();
            obj2.Open();
        }
    }
}
