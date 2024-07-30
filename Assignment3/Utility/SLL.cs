using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int size;

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear() 
        { 
            size = 0;
            head = null;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node { value = value };

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = newNode;
            }

            size++;
        }

        public void AddFirst(User value)
        {
            Node dummy = new Node { value = value };
            dummy.next = head;
            head = dummy;
            size++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == size)
            {
                AddLast(value);
            }
            else
            {
                Node dummy = new Node { value = value };
                Node curr = head;
                for (int i = 0; i < index - 1; i++)
                {
                    curr = curr.next;
                }
                dummy.next = curr.next;
                curr.next = dummy;
                size++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            Node curr = head;

            while (index > 0)
            {
                index--;
                curr = curr.next;
            }
            
            curr.value = value;
        }

        public int Count()
        {
            return size;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list");
            }
            else
            {
                head = head.next;
                size--;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list");
            }

            if (size == 1)
            {
                head = null;
            }
            else
            {
                Node curr = head;
                while (curr.next.next != null)
                {
                    curr = curr.next;
                }
                curr.next = null;
            }

            size--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == size - 1)
            {
                RemoveLast();
            }
            else
            {
                index -= 1;
                Node curr = head;
                while (index > 0)
                {
                    index--;
                    curr = curr.next;
                }
                curr.next = curr.next.next;

            }
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            Node curr = head;

            while (index > 0)
            {
                index--;
                curr = curr.next;
            }

            return curr.value;
        }

        public int IndexOf(User value)
        {
            Node curr = head;
            int index = 0;

            while (curr != null)
            {
                if (curr.value == value)
                {
                    return index;
                }
                curr = curr.next;
                index++;
            }

            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        private Node Recur(Node node)
        {
            if (node == null || node.next == null)
            {
                return node;
            }

            Node tail = Recur(node.next);
            node.next.next = node;
            node.next = null;

            return tail;
        }
        public void ReverseList()
        {
            head = Recur(head);
        }
    }

    public class CannotRemoveException : Exception
    {
        public CannotRemoveException(string message) : base(message) { }
    }
}

