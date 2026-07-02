using System;

class FirstClass{
    int x=10;
    
    void Display(){
        Console.Beep();
        Console.BackgroundColor= ConsoleColor.Red;
        Console.WriteLine("Hello World"+x);
    }

    static void Main(){
        FirstClass obj = new FirstClass();
        obj.Display();
    }
}