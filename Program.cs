using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userNamesList = new List<string>();

            // Collect user names
            while (true)
            {
                Console.Write("Enter the user name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid input! Please enter a valid, non-empty name.");
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    userNamesList.Add(name);
                }

                Console.Write("If you want to exit, type E and then press enter: "); string? enteredValue = Console.ReadLine();

                // Check if user wants to exit
                if (enteredValue.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

            // Display name lengths
            Console.WriteLine("\n ------ Name length for each user ------");
            userNamesList.ForEach(name =>
                Console.WriteLine($"Name: {name.Trim()}, length: {name.Length}")
            );

            // Convert all names to lowercase for case-insensitive processing (and trim the space)
            var lowerCaseNamesList = userNamesList.Select(name => name.ToLower().Trim()).ToList();

            // Group names and identify duplicates and unique names
            var groupedNames = lowerCaseNamesList.GroupBy(name => name);

            // Extract duplicate names
            var duplicateNamesList = groupedNames
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();

            // Extract unique names (in uppercase)
            var uniqueNamesList = groupedNames
                .Where(group => group.Count() < 2)
                .Select(group => group.Key.ToUpper())
                .ToList();

            // Display duplicate names
            Console.WriteLine("\n ------ Duplicate names list ------");
            if (duplicateNamesList.Any())
            {
                Console.WriteLine("Duplicate names: " + string.Join(", ", duplicateNamesList));
            }
            else
            {
                Console.WriteLine("No duplicate names found.");
            }

            // Display unique names
            Console.WriteLine("\n ------ Unique names list ------");
            if (uniqueNamesList.Any())
            {
                Console.WriteLine("Unique names: " + string.Join(", ", uniqueNamesList));
            }
            else
            {
                Console.WriteLine("No unique names found.");
            }
        }
    }
}