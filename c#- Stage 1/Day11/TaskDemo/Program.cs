using System.Threading.Tasks;

//Thread is a very heavy thing thats why tis comes in picture.
//TAP Model-- task asynchronous Programming -- High level abstraction on thread uses concept of thread pool and support asynchronous Programming.

namespace TaskDemo
{
    internal class Program
    {
        async static void Main(string[] args)              //async na likho to bina await ke bhi chlega but await likha to upr async bnana jroori h
        {
            //Asynchronous Programming
            await Task.Run(() => {
                for(int i = 0; i < 10 ; i++)
                {
                    Console.WriteLine("task1");
                    //Task.Delay(1000);
                }
            });

            Task<int> res = Task.Run(() =>
            {
                Console.WriteLine("task2");
                return 10;
            });
            Console.WriteLine(res.Result);
            Console.WriteLine("End of program");

        }
    }
}