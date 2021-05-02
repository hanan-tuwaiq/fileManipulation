using System;
using System.IO;

namespace fileManipulation
{
    class Program
    {
        public static string path = @"C:/Users/hanan/Desktop/Projects/WEEK4DAY1/";
        public static DateTime time = DateTime.Now;
        public static string log = "";
        public static void create()
        {
            //create a file
            Console.WriteLine("Enter File name to create");
            string fileName = Console.ReadLine();
            if (File.Exists(path + fileName + ".txt"))
            {
                Console.WriteLine("File already exists");
            }
            else
            {
                File.Create(path + fileName + ".txt");
                log += "Created " + fileName + ".txt" + " at " + time + ".\n";
            }
        }
        public static void edit()
        {
            //edit a file
            Console.WriteLine("Enter File name to edit");
            string fileName = Console.ReadLine();
            if (File.Exists(path + fileName + ".txt"))
            {
                Console.WriteLine("Enter text:");
                string text = Console.ReadLine();
                File.WriteAllText(path + fileName + ".txt", text);
                log += "Edited " + fileName + ".txt" + " at " + time + ".\n";
            }
            else
            {
                Console.WriteLine("File doesn't exist!");
            }
        }
        public static void delete()
        {
            //delete
            Console.WriteLine("Enter File name to delete");
            string fileName = Console.ReadLine();
            if (File.Exists(path + fileName + ".txt"))
            {
                File.Delete(path + fileName + ".txt");
                log += "Deleted " + fileName + ".txt" + " at " + time + ".\n";
            }
            else
            {
                Console.WriteLine("File doesn't exist!");
            }
        }
        public static void history(string name)
        {
            //write in history
            if (File.Exists("C:/Users/hanan/Desktop/Projects/WEEK4DAY1/history.txt"))
            {
                using (StreamWriter sw = File.AppendText("C:/Users/hanan/Desktop/Projects/WEEK4DAY1/history.txt"))
                {
                    sw.Write(name + " " + log);
                }
            }
            else
            {
                File.WriteAllText("C:/Users/hanan/Desktop/Projects/WEEK4DAY1/history.txt", name + " " + log);
            }
        }
        public static void menu(int operation)
        {
            switch (operation)
            {
                case 1: create();
                    break;
                case 2: edit();
                    break;
                case 3: delete();
                    break;
                default: Console.WriteLine("Error with operation number!");
                    break;
            }
        }
        static void Main(string[] args)
        {
            //ask for name
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            if (name != null)
            {
                //display menu
                Console.WriteLine("1- Create File.");
                Console.WriteLine("2- Edit File.");
                Console.WriteLine("3- Delete File.");
                Console.WriteLine("Enter operation number:");
                int operationNum = Convert.ToInt32(Console.ReadLine());
                menu(operationNum);
                history(name);
            }
        }
    }
}
