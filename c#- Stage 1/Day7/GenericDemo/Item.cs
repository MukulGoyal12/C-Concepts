using System;
using System.Collections.Generic;
using System.Text;

//Mene item me ek parametrized constructor bna dia or Model me bnaya nahi to
//error dega kyuki compiler har class ka automatically constructor bnata hai
//or usme parent ka default call hota hai ab idhr method ka bana pr parent me
//default hua nahi to error aya , to solve krne ken lie ya to item me default
//bnado ya method me khud call krdo.

namespace GenericDemo
{
    //internal class Item
    //{
    //    public int Id {  get; set; }
    //    public Item(int id)
    //    {
    //        Id = id;
    //    }
    //}

    //class Model : Item
    //{
    //    public Model : base(3){}
    //}



    //=================================================


    internal class Item
    {
        public int Id { get; set; }
        public Item(int id)
        {
            Id = id;
        }
    }

    class Model<D>
    {
        public D Id { get; set; }

        public void Func1(D d)
        {
            Console.WriteLine(d);
        }
    }

}
