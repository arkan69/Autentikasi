// See https://aka.ms/new-console-template for more information
namespace Autentikasi;
class Program
{
    static void Main(string[] args)
    {
        
    }

    public void App()
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
                    Create(listUsers);
                    break;
                case 2:
                    ShowUser(listUsers);
                    break;
                case 3:
                    Search(listUsers);
                    break;
                case 4:
                    Login(listUsers);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    App();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR : Input Not Valid");
            Console.ReadKey();
            App();
        }
    }
}