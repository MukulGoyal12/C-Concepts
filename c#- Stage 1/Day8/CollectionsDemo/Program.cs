using System.Collections;

namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            Product p = new Product();
            s.Push(p);
            s.Push("hello");
            s.Push(5);
            object data=s.Pop();
            Console.WriteLine(data);
            Console.WriteLine(s.Pop());


            //===============================================

            Queue q = new Queue();
            q.Enqueue("hello");
            q.Enqueue(new Product(){ Id=1,Name="Mukul", Price=33});
            q.Dequeue();
            Console.WriteLine(q.Count);
            Console.WriteLine(q.Dequeue());

            //====================================================

            Hashtable ht = new Hashtable();
            ht.Add(1,"hello");
            ht.Add(2, 37532);
            ht.Add("hello", "world");
            //ht.Remove(ht.Count-1);
            foreach(object obj in ht.Keys)
            {
                Console.WriteLine(obj );
            }
            foreach (object obj in ht.Values)
            {
                Console.WriteLine(obj);
            }
            foreach (object obj in ht)
            {
                Console.WriteLine(obj);
            }

            //==========================================

            //Initial Capacity hoti hai 0, jaise hi mene kuch add kia vo ho gyi 4 by default jaise hi total of 4 elements ho
            //gye double yani 8 ho jaegi phir dobara double 16 but agr me initial capacity du like 10 to 20 40 8- aise hogi.

            ArrayList list= new ArrayList(3);     //dynamic array   
            Console.WriteLine("capacity: "+list.Capacity);
            list.Add(44);
            list.Add("mukul");
            list.Add(7);
            list.Add(7);
            list.Add(7);
            list.Add(7);
            list.Add(p);
            Console.WriteLine("capacity: " + list.Capacity);
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
            list.Remove(list.Count-1);
            Console.WriteLine("capacity: " + list.Capacity);


        }
    }
}
