﻿// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

namespace Autentikasi;
class Program
{
    static void Main(string[] args)
    {
        Apps();
        
    }

    static void UserMenu()
    {
        Console.Clear();
        Console.WriteLine("==BASIC AUTHENTICATION==");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Show User");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Login User");
        Console.WriteLine("5. Exit");

    }

    static string NameAuth(string nama)
    {
        bool trofal = true;
        if (nama.Length < 2)
        {
            Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
            Console.Write("Input : ");
            nama = Console.ReadLine();
            trofal = false;
            return nama;
        }
        trofal = true;
        return nama;
    }

    static string PasswordAuth(string kataSandi)
    {
        bool trofal;
        do
        {
            if (kataSandi.Length > 7 && kataSandi.Any(char.IsUpper) && kataSandi.Any(char.IsLower) && kataSandi.Any(char.IsNumber))
            {
                trofal = false;
            }
            else
            {
                Console.WriteLine("\nPassword must have at least 8 characters\n with at least one Capital letter, at least one lower case letter and at least one number.");
                Console.Write("Password: ");
                kataSandi = Console.ReadLine();
                trofal = true;
            }
        }
        while (trofal);
        return kataSandi;
    }

    static void Create(List<string> firstname, List<string> lastname, List<string> username, List<string> password)
    {
        Console.Clear();
        Console.Write("First Name: ");
        string first = Console.ReadLine();
        firstname.Add(NameAuth(first));

        Console.Write("Last Name: ");
        string last = Console.ReadLine();
        lastname.Add(NameAuth(last));

        string gabung = first.Substring(0, 2) + last.Substring(0, 2);
        username.Add(gabung);

        Console.Write("Password: ");
        password.Add(PasswordAuth(Console.ReadLine()));

        Pesan("User Created");
        Console.ReadKey(true);

    }

    static void TampilUser(List<string> firstname, List<string> lastname, List<string> username, List<string> password)
    {
        Console.Clear();
        Console.WriteLine("==SHOW USER==");

        int user_id = 0;
        for (int i = 0; i < firstname.Count; i++)
        {
            user_id++;
            Console.WriteLine("========================");
            Console.WriteLine($"ID\t: {user_id}");
            Console.WriteLine($"Name\t: {firstname[i]} {lastname[i]}");
            Console.WriteLine($"Username: {username[i]}");
            Console.WriteLine($"Password: {password[i]}");
            Console.WriteLine("========================");
        }
        Console.WriteLine("\nMenu User");
        Console.WriteLine("1. Edit User");
        Console.WriteLine("2. Delete User");
        Console.WriteLine("3. Back");
    }

    static void EditUser(List<string> firstname, List<string> lastname, List<string> username, List<string> password)
    {
        bool trofal = true;
        do
        {
            Console.Write("Id Yang Ingin Diubah : ");
            int uid = Convert.ToInt32(Console.ReadLine());

            if (uid <= firstname.Count)
            {
                Console.Write("First Name : ");
                string first = Console.ReadLine();
                firstname[uid - 1] = NameAuth(first);

                Console.Write("Last Name : ");
                string last = Console.ReadLine();
                lastname[uid - 1] = NameAuth(last);

                username[uid - 1] = first.Substring(0, 2) + last.Substring(0, 2);

                Console.Write("Password : ");
                password[uid - 1] = PasswordAuth(Console.ReadLine());

                Pesan("Edited");

                Console.ReadKey(true);

                trofal = false;
            }
            else
            {
                Console.WriteLine("User Not Found!!!");
                trofal = true;
            }
        }
        while (trofal);


    }

    static void HapusUser(List<string> firstname, List<string> lastname, List<string> username, List<string> password)
    {
        bool trofal = true;
        do
        {
            Console.Write("Id Yang Ingin Dihapus : ");
            int uid = Convert.ToInt32(Console.ReadLine());

            if (uid <= firstname.Count)
            {
                firstname.RemoveAt(uid - 1);
                lastname.RemoveAt(uid - 1);
                username.RemoveAt(uid - 1);
                password.RemoveAt(uid - 1);

                Pesan("Deleted");

                Console.ReadKey(true);

                trofal = false;
            }
            else
            {
                Console.WriteLine("User Not Found!!!");
                trofal = true;
            }
        }
        while (trofal);
    }

    static void CariUser(List<string> firstname, List<string> lastname, List<string> username, List<string> password)
    {
        Console.WriteLine("==CARI AKUN==");
        Console.Write("Masukan Nama : ");
        string name = Console.ReadLine();

        for (int i = 0; i < firstname.Count; i++)
        {
            if (firstname[i].ToLower().Contains(name.ToLower()) || lastname[i].ToLower().Contains(name.ToLower()))
            {
                Console.WriteLine("========================");
                Console.WriteLine($"ID\t: {i + 1}");
                Console.WriteLine("Name\t: " + firstname[i], lastname[i]);
                Console.WriteLine("Username: " + username[i]);
                Console.WriteLine("Password: " + password[i]);
                Console.WriteLine("========================");
            }
        }
        Console.ReadKey(true);
    }

    static void Login(List<string> username, List<string> password)
    {
        Console.Clear();
        Console.WriteLine("==LOGIN==");
        Console.Write("USERNAME : ");
        string str1 = Console.ReadLine();
        Console.Write("PASSWORD : ");
        string str2 = Console.ReadLine();
        for (int i = 0; i < username.Count; i++)
        {
            if (str1.Equals(username[i]) && str2.Equals(password[i].ToString()))
            {
                Console.WriteLine("MESSAGE : Login Success!");

            }
            else
            {
                Console.WriteLine("User is not exist or username and password doesnt match!");
            }
        }
        Console.ReadKey(true);
    }

    static void Pesan(string pesan)
    {
        Console.WriteLine("User Succes to " + pesan);
    }
}