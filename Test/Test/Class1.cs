using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ObservableCollectionExtensionsDemo
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, List<T> list)
        {
            foreach (var item in list)
            {
                collection.Add(item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an ObservableCollection and a List
            ObservableCollection<int> observableCollection = new ObservableCollection<int>();
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            // Use the AddRange extension method
            observableCollection.AddRange(list);

            // Print all elements in the ObservableCollection to verify the result
            foreach (var item in observableCollection)
            {
                Console.WriteLine(item); // Output: 1 2 3 4 5
            }
        }
    }
}
