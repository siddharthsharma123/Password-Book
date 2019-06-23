using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
    /*This program assumes that the user has the
     * file path: C:\Users\Public\Test Folder\WriteLines.txt already on their computer*/
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fields = { "Account Name", "Username", "Password", "Comments" };
            string[] masterArray = new string[4000];
            //An array is filled with existing accounts from a text file. 
            masterArray = System.IO.File.ReadAllLines(@"C:\Users\Public\Test Folder\WriteLines.txt");
            bool LIMIT = true; 
            while(LIMIT)
            {
                Console.Write("What would you like to do?>>>");
                string firstInput = Console.ReadLine(); 
                //The create function of the program. 
                //Search() loops to the first empty entry, and Create() begins writing
                if(firstInput == "Create" || firstInput == "create")
                {
                    string query = "";
                    int kValue = Search(query, masterArray, fields);
                    Create(kValue, masterArray, fields);
                }
                //The read function of the program. 
                //Search() loops to the desired account and prints the information to the console. 
                if(firstInput == "Read" || firstInput == "read")
                {
                    Console.Write("Which account would you like to view?>>>");
                    string secondInput = Console.ReadLine();
                    Search(secondInput, masterArray, fields); 
                }
                //The update function of the program.
                //Search() loops to the desired account and prints the information to the console. Create() begins writing
                //with user input
                if (firstInput == "Update" || firstInput == "update")
                {
                    Console.Write("Which account would you like to update?>>>");
                    string secondInput = Console.ReadLine();
                    int kValue = Search(secondInput, masterArray, fields);
                    Create(kValue, masterArray, fields);
                    Console.WriteLine("Fields updated");
                }
                //The destroy function of the program. 
                //Search() loops to the desired account and an overloaded Create() destroys the account by replacing the 
                //information with empty strings. 
                if (firstInput == "Destroy" || firstInput == "destroy")
                {
                    Console.Write("Which account would you like to destroy?>>>");
                    string secondInput = Console.ReadLine();
                    int kValue = Search(secondInput, masterArray, fields);
                    Console.Write("Are you sure you want to delete this information(yes/no)?>>>");
                    string decision = Console.ReadLine(); 
                    if(decision == "yes" || decision == "Yes")
                    {
                        Create(kValue, masterArray, fields, decision);
                        Console.WriteLine("Account destroyed");
                    }
                }
                //The stop function of the program. 
                if(firstInput == "stop" || firstInput == "Stop")
                {
                    Console.WriteLine("Thanks for using password book");
                    LIMIT = false;
                }
            }
        }
        //Writes to a text file at a specified value. 
        static void Create(int kValue, string[] array, string[] fields)
        {
            for (int c = 0; c < fields.Length; ++c)
            {
                Console.Write("Enter {0}>>>", fields[c]);
                array[kValue + c] = Console.ReadLine();
            }
            System.IO.File.WriteAllLines(@"C:\Users\Public\Test Folder\WriteLines.txt", array);

        }
        //An overloaded method if the user wants to destroy an account 
        static void Create(int kValue, string[] array, string[] fields, string destroy)
        {
            for (int c = 0; c < fields.Length; ++c)
            {
                array[kValue + c] = "";
            }
            System.IO.File.WriteAllLines(@"C:\Users\Public\Test Folder\WriteLines.txt", array);
        }
        //Searches through an array for a specific value. 
        static int Search(string value, string[] array, string[] fields)
        {
            for(int k =0; k < array.Length; ++k)
            {
                if(array[k] == value && k%4 == 0 && value != "")
                {
   
                    for (int c = 0; c < fields.Length ; ++c)
                    {
                        Console.WriteLine("{0} = {1}", fields[c], array[k+c]);
                    }

                    return k;
                    
                }
                if(array[k] == value && k % 4 == 0 && value == "")
                {
                    return k;
                    
                }
                if(k == array.Length -3)
                {
                    Console.WriteLine("That account was not found");
                    break;
                }
            }
            return -1;
            
        }
    }   
}
