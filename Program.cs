using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using bussiness_application_with__classes.bl;

namespace bussiness_application_with__classes
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<credential> users = new List<credential>();
            List<Users> user = new List<Users>();
            string path = "C:\\Users\\USER\\source\\repos\\bussiness application with  classes\\data.txt";
            int option;
            do
            {
                displaySystem();
                Console.ReadKey();
                readData(path, users);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter your name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter your password : ");
                    string p = Console.ReadLine();
                    signIn(n, p, users);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter new name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter new password : ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            Console.ReadKey();
        }
        

        public static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        public static void readData(string path, List<credential> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    credential info = new credential();
                    info.name = parseData(record, 1);
                    info.password = parseData(record, 2);
                    users.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for(int x = 0; x < record.Length; x++)
            {
                if(record[x] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void signIn(string n, string p, List<credential> user)
        {
            bool flag = false;
            for (int x = 0; x < user.Count; x++)
            {
                if(n == user[x].name && p == user[x].password)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    int choice;
                    Console.WriteLine("Enter choice : ");
                    Console.WriteLine("1.Add user : ");
                    Console.WriteLine("2.Update user : ");
                    Console.WriteLine("3.Read user : ");
                    Console.WriteLine("4.Delete user : ");
                    choice = int.Parse(Console.ReadLine());
                    do
                    {
                        if (choice == 1)
                        {
                            addUser();
                        }
                    }
                    while (choice != -1);
                    break;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        public static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        public static void displaySystem()
        {
            Console.WriteLine("-------------------------------------------------------- ");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("|        WELCOME                                        |");
            Console.WriteLine("|                   TO                                  |");
            Console.WriteLine("|                          BANK                         |");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("|                                                       |");
            Console.WriteLine("-------------------------------------------------------- ");

        }
        public static void addUser(List<Users>user)
        {

        }

        
        
    }
}
