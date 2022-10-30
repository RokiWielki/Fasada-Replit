using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
        int GetCount();
        void DeleteUser(string email);
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {

        }
    }

    class UserRepository
    {
        private readonly List<string> users = new List<string>
        {
            "john.doe@gmail.com", "sylvester.stallone@gmail.com"
        };

        public bool IsEmailFree(string email)
        {
            return !users.Contains(email);
            //dopisz implementacje, która zwróci informacje o tym czy email jest dostępny
        }
        

        public void AddUser(string email)
        {
            users.Add(email);
            Console.WriteLine("Welcome to our service ");
            //dopisz implementacje, która doda użytkownika do listy
        }
        public void Delete(string email)
        {
            users.Remove(email);
            Console.WriteLine("Goodbye "+email);
        }
        public int Countusers()
        {
            return users.Count;
        }
    }

    static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }

    class UserService : UserRepository, IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }

            if (!userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Zajęty email");
            } 

            // TODO: dodaj sprawdzenie czy email jest wolny, jeśli nie to wyrzuć wyjątek, jeśli tak, kontynuuj wykonywanie funkcji

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service");
        }
        public int GetCount()
        {
            return userRepository.Countusers();
        }
        public void DeleteUser(string email)
        {
            userRepository.Delete(email);
        } 



    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            Console.WriteLine("Aktualna liczba adresów: "+ userService.GetCount());
            // TODO: wyświetlić liczbę
            userService.CreateUser("someemail@gmail.com");
            Console.WriteLine("Aktualna liczba adresów: " + userService.GetCount());
            // TODO: wyświetlić liczbę
            userService.DeleteUser("john.doe @gmail.com");
            // TODO: usunąć użytkownika
            Console.WriteLine("Aktualna liczba adresów: " + userService.GetCount());
            // TODO: wyświetlić liczbę
            
        }
    }

}