using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderExtensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to count its words:");
            string userInput = Console.ReadLine();

            StringBuilder sb = new StringBuilder(userInput);

            int count = sb.WordCount();
            Console.WriteLine($"The number of words is: {count}");
        }
    }
}