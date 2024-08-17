using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Assignment1
{
    internal class Program
    {
        //To test the Project please place comments where i have marked Q1 - Q1 for Question1 and Q2- Q2 for Question 2 and Q3 - Q3 for Question 3 
        static void Main(string[] args)
        {
          //Q1
          // Question 1 
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop()); // Output: 3
            Console.WriteLine(stack.Pop()); // Output: 2
            Console.WriteLine(stack.Pop()); // Output: 1

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Dequeue()); // Output: 1
            Console.WriteLine(queue.Dequeue()); // Output: 2
            Console.WriteLine(queue.Dequeue()); // Output: 3
            Console.ReadKey();
            //Q1
            
            
            //Q2
            //Question 2
            //Data Processor 
            DataProcesso<int> processor = new DataProcesso<int>();
            Console.WriteLine(processor.Max(3, 5)); // Output: 5        
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
            Console.ReadKey();
            //Q2
            
            //Q3
            
            string filePath = "D:\\OneDrive - Centennial College\\Downloads\\7Programming_Temp\\Docs\\Assignment#1\\auto-mpg.csv"; 
            SinglyLinkedList<Vehicle> vehicleList = new SinglyLinkedList<Vehicle>();
            var vehicles = LoadVehicles(filePath);
            // Add vehicles to the linked list
            foreach (var vehicle in vehicles)
            {
                vehicleList.AddLast(vehicle); 
            }
            // Print all vehicles
            vehicleList.PrintAll();
            Console.ReadKey();  
        }
            public static List<Vehicle> LoadVehicles(string filePath)
            {
                var vehicles = new List<Vehicle>();
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var columns = line.Split(',');
              
                    if (columns.Length >= 7)
                    {
                        vehicles.Add(new Vehicle
                        {
                            Name = columns[6],
                            Mpg = ParseDouble(columns[0]),
                            Cylinders = ParseInt(columns[1]),
                            Horsepower = ParseDouble(columns[2]),
                            Weight = ParseDouble(columns[3]),
                            Acceleration = ParseDouble(columns[4]),
                            ModelYear = ParseInt(columns[5])
                        });
                    }
                }
                return vehicles;
            }
            public static double ParseDouble(string value)
            {
                double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result);
                return result;
            }
            public static int ParseInt(string value)
            {
                int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int result);
                return result;
            
            //Q3
            }
    }
}