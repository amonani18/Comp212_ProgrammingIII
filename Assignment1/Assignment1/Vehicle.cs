using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment1
{
    public class Vehicle
    {
        public string Name { get; set; }
        public double Mpg { get; set; }
        public int Cylinders { get; set; }
        public double Displacement { get; set; }
        public double Horsepower { get; set; }
        public double Weight { get; set; }
        public double Acceleration { get; set; }
        public int ModelYear { get; set; }
        public string Origin { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} MPG, {2} Cylinders, {3} Displacement, {4} HP, {5} Weight, {6} Acceleration, {7} Model Year, {8}",
                                 Name, Mpg, Cylinders, Displacement, Horsepower, Weight, Acceleration, ModelYear, Origin);
        }
    }
}