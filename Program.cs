using System;
using Kodanalys.Models;

namespace Kodanalys
{
    class Program 
    {
        static User[] users = new User[10]; //Limited to 10 users.

        static int userCount = 0; 

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
                        if (userCount < 10)
                        {
                            users[userCount] = new User();
                            users[userCount].Name = userName;
                            userCount++;
                        }
                        else
                        {
                            Console.WriteLine("Listan är full!");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Användare:");
                        for (int i = 0; i < userCount; i++)
                        {
                            Console.WriteLine(users[i].Name);
                        }
                        break;
                    case "3":
                        Console.Write("Ange namn att ta bort: ");
                        string removeUsernameInput = Console.ReadLine()!;
                        int userIndex = -1;
                        //
                        for (int i = 0; i < userCount; i++)
                        {
                            if (users[i].Name == removeUsernameInput)
                            {
                                userIndex = i;
                                break;
                            }
                        }

                        if (userIndex != -1)
                        {
                            for (int i = userIndex; i < userCount - 1; i++)
                            {
                                users[i] = users[i + 1];
                            }
                            userCount--;
                        }
                        else
                        {
                            Console.WriteLine("Användaren hittades inte.");
                        }
                        break;
                    case "4":
                        Console.Write("Ange namn att söka: ");
                        string searchUsernameInput = Console.ReadLine()!;
                        bool isFound = false;
                        for (int i = 0; i < userCount; i++)
                        {
                            if (users[i].Name == searchUsernameInput)
                            {
                                isFound = true;
                                break;
                            }
                        }
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
