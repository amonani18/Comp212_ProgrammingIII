using Stack_SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
/*
 * Student Name - Aniket Monani
 * Student ID - 301422485
*/
namespace Stack_SinglyLinkedList
{
    // Generic stack implementation using SinglyLinkedList
    public class Stack4COMP212<T> where T : IEquatable<T>
    {
        private SinglyLinkedList<T> list = new SinglyLinkedList<T>();

        // Push method adds an element to the top of the stack
        public void Push(T e)
        {
            list.AddFirst(e);
        }

        // Pop method removes the top element of the stack and returns it
        public T? Pop()
        {
            return list.RemoveFirst();
        }

        // Peek method returns the top element without removing it
        public T? Peek()
        {
            return list.First();
        }

        // Contains method checks if the element exists in the stack
        public bool Contains(T e)
        {
            return list.Search(e);
        }

        // ToArray method returns an array of the stack elements
        public T[] ToArray()
        {
            return list.Traverse().ToArray();
        }
    }
}
