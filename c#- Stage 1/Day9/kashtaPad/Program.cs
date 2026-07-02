using System.IO;
using static System.Console;

namespace kashtaPad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("1. Write File  2.Read File");
            int choice = Convert.ToInt32(ReadLine());
            WriteLine("Enter File Path:");
            string path = null;
            path= ReadLine();
            switch(choice)
            {
                case 1:
                    WriteToFile(path);
                    break;
                case 2:
                    ReadFromFile(path);
                    break;
                case 3:
                    Console.WriteLine("padh lie?");
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }

        }

        static void WriteToFile(string path)
        {
            WriteLine("Enter Data");
            string data = ReadLine();

            //create a text file write
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(@path);
                writer.Write(data);        //write data to object - capacity 2gb. is 2gb data is filled
                                           //it flush data from data to disc thats why flush in next line.
                writer.Flush();
            }
            catch (IOException e) { return; }
            catch (Exception e)
            {
                WriteLine(e.Source);
            }
            finally
            {
                writer.Close();
            }
        }

        static void ReadFromFile(string path)
        {
            StreamReader reader=null;
            try
            {
                reader = new StreamReader(@path);
                string data = reader.ReadToEnd();
                WriteLine(data);   

            }
            finally
            {
                reader.Close();
            }
        }
    }
}

//catch(Exception e) { }     generic catch function  
//catch { }                  generic catch block