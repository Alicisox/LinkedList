using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class LinkedList : Node
    {
        Node head; // Front pointer
        Node tail; // Rear pointer
        int length;

        public LinkedList() {
            this.head = this.tail = null;
            this.length = 0;
        }

        public int Legnth { get { return this.length; } }

        /// <summary>
        /// Insert an element at the end of the list.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be inserted.
        /// </param>
        public void Append(int? value) { // or Push
            // Set head and tail if Node has ever presented before
            if (this.length == 0)
            {
                this.head = new Node(value);
            }
            else if (this.length == 1) 
            {
                this.head.Next = this.tail = new Node(value);
            } else
            {
                Node current = this.head;
                while (current.Next != null) {
                    current = current.Next;
                }
                current.Next = new Node(value);
                this.tail = current.Next;
            }
            this.length++;
        }

        /// <summary>
        /// Insert an element at the front of the list.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be inserted.
        /// </param>
        public void Prepend(int? value) {
            if (this.length == 0)
            {
                this.head = new Node(value);
            }
            else
            {
                Node tmp_pvt = this.head;
                this.head = new Node(value);
                this.head.Next = tmp_pvt;
            }
            this.length++;
        }

        /// <summary>
        /// Insert an element by given index.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be inserted.
        /// <c>index</c> is position to be inserted.
        /// </param>
        public void Insert(int? value, int index) {
            if (index > length) return;
            if (length == 0) {
                this.head = this.tail = new Node(value);
                this.length++;
            }
            else if (length == 1)
            {
                this.tail = new Node(value);
                this.head.Next = this.tail;
                this.length++;
            }
            else
            {
                Node current = this.head;
                int num = 0;

                while (current != null)
                {
                    if (num == index)
                    {
                        if (num == length - 1) // At the end of the list 
                        {
                            current.Next = new Node(value);
                            this.tail = current.Next; // set new tail
                        }
                        else // In the middle of the list
                        {
                            Node tmp_pvt = current.Next;
                            current.Next = new Node(value);
                            current.Next.Next = tmp_pvt;

                        }
                    }
                    num++;
                    this.length++;
                    current = current.Next;
                }
            }

        }

        /// <summary>
        /// Remove an element at the end of the list.
        /// </summary>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool Pop() {
            if (this.length == 0) return false;
            if (this.length == 1)
            {
                Console.WriteLine("Removed {0}!", this.head.Value);
                this.head = this.tail = null;
                this.length--;
                return true;
            }
            Node current = this.head;
            Node previous = this.head;
            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
            }
            tail = previous;
            Console.WriteLine("Removed {0}!", previous.Next.Value);
            previous.Next = null;
            this.length--;
            return true;
        }

        /// <summary>
        /// Remove an element at the front of the list.
        /// </summary>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool Remove() {
            if (this.length == 0) return false;
            if (this.length == 1)
            {
                Console.WriteLine("Removed {0}!", this.head.Value);
                this.head = this.tail = null;
                this.length--;
                return true;
            }
            Console.WriteLine("Removed {0}!", this.head.Value);
            this.head = this.head.Next;
            this.length--;
            return true;
        }

        /// <summary>
        /// Remove an element by given value.
        /// </summary>
        /// <param>
        /// <c>value</c> is value to be removed.
        /// </param>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool Remove(int? value)
        {
            if (this.length == 0) return false;
            if (this.length == 1 && this.head.Value == value)
            {
                Console.WriteLine("Removed {0}!", this.head.Value);
                this.head = this.tail = null;
                this.length--;
                return true;
            }
            Node previous = this.head;
            Node current = this.head;
            
            while (current != null)
            {
                if (current.Value == value) {
                    if (current.Next == null) // At the end of the list 
                    {
                        previous.Next = null;
                        this.tail = previous; // set new tail
                    }
                    else if (current == this.head) { // At the beginning of the list 
                        this.head = previous.Next;
                    }
                    else // In the middle of list
                    {
                        previous.Next = current.Next; // x -> current -> y to x -> y

                    }
                    Console.WriteLine("Removed {0}!", value);
                    this.length--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Return a value in the list by given index.
        /// </summary>
        /// <param>
        /// <c>index</c> is the index of value.
        /// </param>
        /// <returns>
        /// The int value.
        /// </returns>
        public int? GetValue(int index) { 
            if (index > this.length - 1 || this.length == 0) return -1;
            if (this.length == 1) return this.head.Value;
            Node current = this.head;
            int num = 0;
            while (current != null)
            {
                if (num == index)
                {
                    return current.Value;
                }
                num++;
                current = current.Next; // next node
            }
            return -1;
        }

        /// <summary>
        /// Set value in the list by given index and value.
        /// </summary>
        /// <param>
        /// <c>value</c> is the value to be set.
        /// <c>index</c> is the index of the value.
        /// </param>
        public void SetValue(int value, int index) { 
            if (this.length == 0) return;
            if (this.length == 1) this.head.Value = value;
            Node current = this.head;
            int num = 0;
            while (current != null)
            {
                if (num == index)
                {
                    current.Value = value;
                }
                num++;
                current = current.Next; // next node
            }
        }

        /// <summary>
        /// Remove an element by given index.
        /// </summary>
        /// <param>
        /// <c>index</c> is index of value that want to be removed.
        /// </param>
        /// <returns>
        /// The bool, if it successfully removes return true else false.
        /// </returns>
        public bool RemoveByIndex(int index) {
            if (this.length == 0) return false;
            if (this.length == 1)
            {
                Console.WriteLine("Removed {0}!", this.head.Value);
                this.head = this.tail = null;
                this.length--;
                return true;
            }
            Node previous = this.head;
            Node current = this.head;
            int num = 0;
            while (current != null)
            {
                if (num == index)
                {
                    Console.WriteLine("Removed {0}!", current.Value);
                    if (current.Next == null) // At the end of the list 
                    {
                        previous.Next = null;
                        this.tail = previous; // set new tail
                    }
                    else if (current == this.head)
                    { // At the beginning of the list 
                        this.head = previous.Next;
                    }
                    else // In the middle of list
                    {
                        previous.Next = current.Next; // x -> current -> y to x -> y

                    }
                    this.length--;
                    return true;
                }
                num++;
                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Search the node that contains given value.
        /// </summary>
        /// <param>
        /// <c>value</c> is number to find the node.
        /// </param>
        /// <returns>
        /// The node of given number.
        /// </returns>
        public Node Search(int? value)
        {
            if (this.length == 0)
            {
                return null;
            }
            Node current = this.head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }
                current = current.Next; // next node
            }
            return null;
        }

        /// <summary>
        /// Reverse the list by changing the pointer to an opposite side.
        /// </summary>
        public void Reverse() {
            if (this.length == 0 || this.length == 1)
            {
                return;
            }
            Node current = this.head;
            Node previous = null; //tmp
            Node Next_pvt;
            this.tail = current; // Set tail
            while (current != null)
            {
                if (current.Next == null) // Last element
                {
                    this.head = current;
                }
                Next_pvt = current.Next; // Save next pvt
                // Rotate left pointer into right pointer (opposite site)
                current.Next = previous;
                previous = current;
                current = Next_pvt; // next node
            }
        }

        /// <summary>
        /// Print all values of the list.
        /// </summary>
        public void Traverse() {
            if (this.length == 0)
            {
                return;
            }
            Node current = this.head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next; // next node
            }
            Console.WriteLine(" null ");
        }
    }
}
