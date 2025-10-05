using System;
using Kodanalys.Models;

namespace Kodanalys
{
    class Program 
    {
        static List<User> users = new List<User>();

        static int maxUsers = 10; 

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Lägg till användare");
                Console.WriteLine("2. Visa alla användare");
                Console.WriteLine("3. Ta bort användare");
                Console.WriteLine("4. Sök användare");
                Console.WriteLine("5. Avsluta");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.Write("Ange namn: ");
                        string userName = Console.ReadLine()!;
                        if (users.Count < maxUsers)
                        {
                            users.Add (new User (userName));
                            
                        }
                        else
                        {
                            Console.WriteLine("Listan är full!");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Användare:");
                        foreach (string u in users.Select(user => user.Name))
                        {
                            Console.WriteLine(u);
                        }
                        break;
                    case "3":
                        Console.Write("Ange namn att ta bort: ");
                        string usernameInput = Console.ReadLine()!.ToLower()!;
                        var userToRemove = users.FirstOrDefault(user => user.Name.ToLower() == usernameInput);
                        if (userToRemove != null)
                        {
                            users.Remove(userToRemove);
                            Console.WriteLine("Användaren har tagits bort.");
                        }
                        else
                        {
                            Console.WriteLine("Användaren hittades inte.");
                        }
                        break;
                    case "4":
                        Console.Write("Ange namn att söka: ");
                        string searchName = Console.ReadLine()!.ToLower()!;
                        bool isFound = users.Any(user => user.Name.ToLower() == searchName);

                        if (isFound)
                        {
                            Console.WriteLine("Användaren finns i listan.");
                        }
                        else
                        {
                            Console.WriteLine("Användaren hittades inte.");
                        }
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}
