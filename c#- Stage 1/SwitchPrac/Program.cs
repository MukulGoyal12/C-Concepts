using System;

namespace Report_Card
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your grade");
            string grade = Console.ReadLine();
            string result = grade switch
            {
                "A" or "B" => "Excellent",
                "C" => "Good",
                "D" => "NeedsImprovement",
                "E" => "Poor",
                _ => "Wrong Choice"
            };
            Console.WriteLine("You are: " + result);
            Console.WriteLine("Enter your marks");
            if (int.TryParse(Console.ReadLine(), out int marks))
            {
                var res = marks switch
                {
                    > 80 => "Excellent",
                    > 60 => "Good",
                    _ => "Failed"
                };
                Console.WriteLine("You are: " + res);
            }

            (float salary, int age) person = (5000, 23);
            var isMillionare = person switch
            {
                var (salary, age) when salary > 5000 && age > 45 => "you are millionaire",
                var (salary, age) when salary > 100000 && age > 23 => "you can become a millionaire",
                _ => "beggars are not allowed"
            };
            Console.WriteLine(isMillionare);
            var var1 = $"hello {isMillionare}";

            // Raw strings

            var var2 = """
                {
                    "name": "nainshi",
                    "age": """ + grade + """
                }
                """;

            // Interpolated raw strings

            var VAR3 = $$"""
                {
                    "name": {{isMillionare}},
                    "age": {{grade}}
                }
                """;

            //verbating string
            var var4 = @"hello\n";
            Console.WriteLine(var4);
            var filepath = @"C:\Users\2492313\C#_Basics";
            Console.WriteLine(filepath);
        }
    }
}