using System;
using System.Collections.Generic;
/*
 * Student Name - Aniket Monani
 * Student ID - 301422485
*/
namespace Stack_SinglyLinkedList
{
    // SinglyLinkedList implementation to manage the stack elements
    public class SinglyLinkedList<T> where T : IEquatable<T>
    {
        private class Node
        {
            private T element;
            private Node next;

            internal Node(T e, Node n)
            {
                element = e;
                next = n;
            }

            internal T GetElement() { return element; }
            internal Node GetNext() { return next; }
            internal void SetNext(Node? n) { next = n; }
        }

        private Node? headNode = null;  // Head node of the list
        private Node? tailNode = null;  // Tail node of the list
        private int size = 0;           // Number of nodes in the list

        public SinglyLinkedList() { }

        public int GetSize() { return size; }
        public bool IsEmpty() { return size == 0; }

        // Returns the first element without removing it
        public T? First()
        {
            if (IsEmpty()) return default(T);
            return headNode.GetElement();
        }

        // Returns the last element without removing it
        public T? Last()
        {
            if (IsEmpty()) return default(T);
            return tailNode.GetElement();
        }

        // Adds an element to the front of the list
        public void AddFirst(T e)
        {
            headNode = new Node(e, headNode);
            if (size == 0)
                tailNode = headNode;
            size++;
        }

        // Adds an element to the end of the list
        public void AddLast(T e)
        {
            Node newest = new Node(e, null);
            if (IsEmpty())
                headNode = newest;
            else
                tailNode.SetNext(newest);
            tailNode = newest;
            size++;
        }

        // Removes and returns the first element
        public T? RemoveFirst()
        {
            if (IsEmpty()) return default(T);
            T answer = headNode.GetElement();
            headNode = headNode.GetNext();
            size--;
            if (size == 0)
                tailNode = null;
            return answer;
        }

        // Removes and returns the last element
        public T? RemoveLast()
        {
            if (IsEmpty()) return default(T);
            Node walk = headNode;
            Node previous = null;
            while (walk.GetNext() != null)
            {
                previous = walk;
                walk = walk.GetNext();
            }

            T answer = walk.GetElement();
            if (previous != null)
                previous.SetNext(null);
            else
                headNode = null;

            tailNode = previous;
            size--;
            return answer;
        }

        // Searches for an element in the list
        public bool Search(T e)
        {
            Node? walk = headNode;
            while (walk != null)
            {
                if (walk.GetElement().Equals(e))
                    return true;
                walk = walk.GetNext();
            }
            return false;
        }

        // Traverses the list and returns an IEnumerable of the elements
        public IEnumerable<T> Traverse()
        {
            Node? walk = headNode;
            while (walk != null)
            {
                yield return walk.GetElement();
                walk = walk.GetNext();
            }
        }
    }
}
