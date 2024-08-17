using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Search
{
/*
 * Developed By Aniket Monani
 * Student Id - 301422485
 */
    internal class SearchHelper
    {
        public static int Search<T>(T[] array, T key) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(key) == 0)
                    return i; // Return the index of the element if found
            }
            return -1; // Return -1 if the element is not found
        }
    }
}
