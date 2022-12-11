// See https://aka.ms/new-console-template for more information
namespace Autentikasi;
class Program
{
    private Crud crud = new Crud();
    private List<User> listUsers = new List<User>();
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

        /*static void Search(List<User> listUsers)
        {
            List<User> userList = new List<User>();
            Console.Clear();
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();
            this.crud.View(listUsers.Where<User>((Func<User, bool>)(i => i.FirstName.ToLower().Contains(name.ToLower()) || i.LastName.ToLower().Contains(name.ToLower()))).Select<User, User>((Func<User, User>)(g => new User()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                UserName = g.UserName,
                Password = g.Password
            })).ToList<User>());
            Console.ReadKey();
            App();
        }

        static void Create(List<User> listUser)
        {
            Auth auth = new Auth();
            Console.Clear();
            Console.Write("First Name: ");
            string firstName = auth.NameAuth(Console.ReadLine());
            Console.Write("Last Name: ");
            string lastName = auth.NameAuth(Console.ReadLine());
            Console.Write("Password: ");
            string password = auth.PasswordAuth(Console.ReadLine());
            User user = new User(firstName, lastName, password);
            Console.WriteLine(this.crud.Create(listUser, user));
            Console.ReadKey();
            App();
        }

        void Login(List<User> listUser)
        {
            Auth auth = new Auth();
            Console.Clear();
            Console.WriteLine("==LOGIN==");
            Console.Write("USERNAME : ");
            string str1 = Console.ReadLine();
            Console.Write("PASSWORD : ");
            string str2 = Console.ReadLine();
            List<User> listUser1 = listUser;
            string namaUser = str1;
            string kataSandi = str2;
            if (auth.Authentication(listUser1, namaUser, kataSandi))
            {
                Console.WriteLine("Login Berhasil!");
                Console.ReadKey();
                App();
            }
            else
            {
                Console.WriteLine("Username atau Password Tidak Ditemukan");
                Console.ReadKey();
                App();
            }
        }

        static void EditUser(List<User> users, User user)
        {
            bool flag;
            do
            {
                Console.Write("Id Yang Ingin Diubah : ");
                int int32 = Convert.ToInt32(Console.ReadLine());
                if (int32 <= users.Count)
                {
                    Console.Write("First Name : ");
                    user.FirstName = Console.ReadLine();
                    Console.Write("Last Name : ");
                    user.LastName = Console.ReadLine();
                    Console.Write("Password : ");
                    user.Password = Console.ReadLine();
                    Console.WriteLine(this.crud.Edit(users, user, int32));
                    flag = false;
                }
                else
                {
                    Console.WriteLine("User Tidak Ditemukan!!!");
                    flag = true;
                }
            }
            while (flag);
            Console.ReadKey();
            ShowUser(users);
        }

        static void DeleteUser(List<User> users)
        {
            Console.Write("Id Yang Ingin Dihapus : ");
            int int32 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.crud.Delete(users, int32));
            Console.ReadKey();
            ShowUser(users);
        }

        static void ShowUser(List<User> users)
        {
            User user = new User();
            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            this.crud.View(users);
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    EditUser(users, user);
                    break;
                case 2:
                    DeleteUser(users);
                    break;
                case 3:
                    App();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    ShowUser(users);
                    break;
            }
        }*/
    }
}

