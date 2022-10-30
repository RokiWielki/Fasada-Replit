using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {
            Console.WriteLine("Sending an email");
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
            throw new NotImplementedException();
            //dopisz implementacje, która zwróci informacje o tym czy email jest dostępny
        }

        public void AddUser(string email)
        {
            throw new NotImplementedException();
            //dopisz implementacje, która doda użytkownika do listy
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

    class UserService : IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }

            // TODO: dodaj sprawdzenie czy email jest wolny, jeśli nie to wyrzuć wyjątek, jeśli tak, kontynuuj wykonywanie funkcji

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            // TODO: wyświetlić liczbę
            userService.CreateUser("someemail@gmail.com");
            // TODO: wyświetlić liczbę
            // TODO: usunąć użytkownika
            // TODO: wyświetlić liczbę
        }
    }

}