using Stack_SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.IO;
/*
 * Student Name - Aniket Monani
 * Student ID - 301422485
*/
namespace Stack_SinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack4COMP212<Session>();

            // Load data from CSV
            var sessions = LoadSessionsFromCsv("Sessions.csv");
            foreach (var session in sessions)
            {
                stack.Push(session);
            }

            // Invoke toArray() and print out all elements
            var sessionArray = stack.ToArray();
            foreach (var session in sessionArray)
            {
                Console.WriteLine(session);
            }

            // Prevent console from closing immediately
            Console.ReadKey();
        }

        // Method to load sessions from CSV file
        private static List<Session> LoadSessionsFromCsv(string filePath)
        {
            var sessions = new List<Session>();

            using (var reader = new StreamReader(filePath))
            {
                // Skip the header line
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // Create a Session object and add it to the list
                    var session = new Session(
                        values[0],
                        values[1],
                        values[2],
                        int.Parse(values[3])
                    );

                    sessions.Add(session);
                }
            }

            return sessions;
        }
    }
}
