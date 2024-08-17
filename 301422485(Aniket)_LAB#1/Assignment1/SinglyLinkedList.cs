using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class SinglyLinkedList<E>
    {
        private Node<E> head;
        private Node<E> tail;
        private int size;

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void AddFirst(E element)
        {
            Node<E> newNode = new Node<E>(element, head);
            head = newNode;
            if (size == 0)
            {
                tail = head;
            }
            size++;
        }

        public void AddLast(E element)
        {
            Node<E> newNode = new Node<E>(element, null);
            if (size == 0)
            {
                head = newNode;
            }
            else
            {
                tail.SetNext(newNode);
            }
            tail = newNode;
            size++;
        }

        public E First()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty");
            return head.GetElement();
        }

        public E Last()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty");
            return tail.GetElement();
        }

        public E RemoveFirst()
        {
            if (IsEmpty()) throw new InvalidOperationException("List is empty");
            E element = head.GetElement();
            head = head.GetNext();
            size--;
            if (size == 0)
            {
                tail = null;
            }
            return element;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<E> current = head;
            while (current != null)
            {
                sb.Append(current.GetElement());
                if (current.GetNext() != null)
                {
                    sb.Append(" -> ");
                }
                current = current.GetNext();
            }
            return sb.ToString();
        }
        public void PrintAll()
        {
            Node<E> current = head?.GetNext();
            while (current != null)
            {
                Vehicle vehicle = current.GetElement() as Vehicle;
                if (vehicle != null)
                {
                    Console.WriteLine($"{"Name:",-20}{vehicle.Name}");
                    Console.WriteLine($"{"Miles Per Gallon:",-20}{vehicle.Mpg}");
                    Console.WriteLine($"{"Cylinders:",-20}{vehicle.Cylinders}");
                    Console.WriteLine($"{"Horsepower:",-20}{vehicle.Horsepower}");
                    Console.WriteLine($"{"Weight:",-20}{vehicle.Weight}");
                    Console.WriteLine($"{"Acceleration:",-20}{vehicle.Acceleration}");
                    Console.WriteLine($"{"Model Year:",-20}{vehicle.ModelYear}");
                    Console.WriteLine();
                }
                    current = current.GetNext();
            }
        }
        public class Node<T>
        {
            private T element;
            private Node<T> next;

            public Node(T element, Node<T> next)
            {
                this.element = element;
                this.next = next;
            }

            public T GetElement()
            {
                return element;
            }

            public Node<T> GetNext()
            {
                return next;
            }

            public void SetNext(Node<T> next)
            {
                this.next = next;
            }
        }
    }
}
