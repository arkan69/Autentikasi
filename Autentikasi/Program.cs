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

/*class User
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public User(string firstName, string lastName, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = firstName.Substring(0, 2) + lastName.Substring(0, 2);
        Password = password;
    }

    public User()
    {
    }
}

// Decompiled with JetBrains decompiler
// Type: Authentication.Crud
// Assembly: Authentication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6E70486A-E2F7-4569-8D9C-DD18D9284150
// Assembly location: D:\COBA\Authentication.dll


class Crud
    {
        public string Create(List<User> users, User user)
        {
            if (new Auth().UserAuth(users, user.UserName))
                return Success(nameof(Create), "Username");
            users.Add(user);
            return Success("Created");
        }

        public string Edit(List<User> users, User user, int id)
        {
            users[id - 1].FirstName = user.FirstName;
            users[id - 1].LastName = user.LastName;
            users[id - 1].UserName = user.FirstName.Substring(0, 2) + user.LastName.Substring(0, 2);
            users[id - 1].Password = user.Password;
            return Success("Edited");
        }

        public string Delete(List<User> users, int id)
        {
            if (id > users.Count)
                return NotFound();
            users.RemoveAt(id - 1);
            return Success("Deleted");
        }

        public void View(List<User> Users)
        {
            int num = 0;
            foreach (User user in Users)
            {
                ++num;
                Console.WriteLine("========================");
                Console.WriteLine(string.Format("ID\t: {0}", (object)num));
                Console.WriteLine("Name\t: " + user.FirstName + " " + user.LastName);
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("Password: " + user.Password);
                Console.WriteLine("========================");
            }
        }

        private string NotFound() => "User Not Found!!!";

        private string Success(string value) => "User Success to " + value + "!!!";

        private string Success(string value, string error) => value + " failure," + error + " already exists!!!";
    }

class Auth
{
    public bool Authentication(List<User> listUser, string namaUser, string kataSandi)
    {
        bool flag = false;
        for (int index = 0; index < listUser.Count; ++index)
        {
            if (namaUser == listUser[index].UserName && kataSandi == listUser[index].Password)
            {
                flag = true;
                break;
            }
        }
        Console.Write("MESSAGE : ");
        return flag;
    }

    public string NameAuth(string nama)
    {
        bool flag = true;
        if (nama.Length < 2)
        {
            Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
            Console.Write("Input : ");
            nama = Console.ReadLine();
            flag = false;
            return nama;
        }
        flag = true;
        return nama;
    }

    public string PasswordAuth(string kataSandi)
    {
        bool flag;
        do
        {
            if (kataSandi.Length > 7 && kataSandi.Any<char>(new Func<char, bool>(char.IsUpper)) && kataSandi.Any<char>(new Func<char, bool>(char.IsLower)) && kataSandi.Any<char>(new Func<char, bool>(char.IsNumber)))
            {
                flag = false;
            }
            else
            {
                Console.WriteLine("\nPassword must have at least 8 characters\n with at least one Capital letter, at least one lower case letter and at least one number.");
                Console.Write("Password: ");
                kataSandi = Console.ReadLine();
                flag = true;
            }
        }
        while (flag);
        return kataSandi;
    }

    public bool UserAuth(List<User> users, string userName)
    {
        for (int index = 0; index < users.Count; ++index)
        {
            if (users[index].UserName == userName)
                return true;
        }
        return false;
    }
}

class Crud
{
    public string Create(List<User> users, User user)
    {
        if (new Auth().UserAuth(users, user.UserName))
            return Success(nameof(Create), "Username");
        users.Add(user);
        return Success("Created");
    }

    public string Edit(List<User> users, User user, int id)
    {
        users[id - 1].FirstName = user.FirstName;
        users[id - 1].LastName = user.LastName;
        users[id - 1].UserName = user.FirstName.Substring(0, 2) + user.LastName.Substring(0, 2);
        users[id - 1].Password = user.Password;
        return Success("Edited");
    }

    public string Delete(List<User> users, int id)
    {
        if (id > users.Count)
            return NotFound();
        users.RemoveAt(id - 1);
        return Success("Deleted");
    }

    public void View(List<User> Users)
    {
        int num = 0;
        foreach (User user in Users)
        {
            ++num;
            Console.WriteLine("========================");
            Console.WriteLine(string.Format("ID\t: {0}", (object)num));
            Console.WriteLine("Name\t: " + user.FirstName + " " + user.LastName);
            Console.WriteLine("Username: " + user.UserName);
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("========================");
        }
    }

    private string NotFound() => "User Not Found!!!";

    private string Success(string value) => "User Success to " + value + "!!!";

    private string Success(string value, string error) => value + " failure," + error + " already exists!!!";
}*/