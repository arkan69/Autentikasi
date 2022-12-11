// See https://aka.ms/new-console-template for more information
namespace Autentikasi;
class Program
{
    static void Main(string[] args)
    {
        Apps();
    }

    static void Apps()
    {
        Console.Clear();
        Console.WriteLine("==BASIC AUTHENTICATION==");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show User");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Login User");
        Console.WriteLine("5. Exit");
        Console.Write("Input : ");
        try
        {
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Create();
                    break;
                case 2:
                    //ShowUser(listUsers);
                    Console.WriteLine("Show User!!");
                    break;
                case 3:
                    //Search(listUsers);
                    Console.WriteLine("Search User!!");
                    break;
                case 4:
                    //Login(listUsers);
                    Console.WriteLine("Login User!!");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    Apps();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            Apps();
        }
    }

    static void Create()
    {
        string username, password;
        Console.Write("Create Username : "); username = Convert.ToString(Console.ReadLine());
        Console.Write("Create Password : "); password = Convert.ToString(Console.ReadLine());
    }
}