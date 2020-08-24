using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListProject
{
    public class LinkedList
    {
        public LinkedList() { }
        public Node Head { get; set; }
        public int Length { get; set; }
        public Node Tail { get; set; }

        public LinkedList(int[] array)
        {
            if (array == null)
                Errors.NullHead();

            Head = new Node(array[0]);
            Tail = Head;
            Length = 1;

            for (int i = 1; i < array.Length; i++)
            {
                Tail.Next = new Node(array[i]);
                Tail = Tail.Next;
            }

            Length = array.Length;
        }

        public void AddFirst(int value)
        {
            Node node = new Node(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Length++;
        }

        public void AddFirst(int[] values)
        {
            LinkedList arrayValue = new LinkedList(values);

            if (Head == null)
            {
                Head = arrayValue.Head;
                Tail = arrayValue.Tail;
            }
            else
            {
                arrayValue.Tail.Next = Head;
                Head = arrayValue.Head;
            }

            Length += arrayValue.Length;

        }

        public void AddLast(int value)
        {
            Node node = new Node(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Length++;
        }

        public void AddLast(int[] values)
        {
            LinkedList arrayValue = new LinkedList(values);

            if (Head == null)
            {
                Head = arrayValue.Head;
                Tail = arrayValue.Tail;
            }
            else
            {
                Tail.Next = arrayValue.Head;
                Tail = arrayValue.Tail;
            }

            Length += arrayValue.Length;
        }

        public void AddAt(int idx, int value)
        {
            if (idx < 0)
            {
                Errors.IndexIsIncorrect();
                return;
            }

            if (idx >= Length)
            {
                AddLast(value);
            }
            else if (idx == 0)
            {
                AddFirst(value);
            }
            else
            {
                Node tmpNode = Head;
                Node node = new Node(value);
                for (int counter = 1; counter < idx; counter++)
                {
                    tmpNode = tmpNode.Next;
                }
                node.Next = tmpNode.Next;
                tmpNode.Next = node;
                Length++;
            }
        }

        public void AddAt(int idx, int[] values)
        {
            LinkedList arrayValue = new LinkedList(values);

            if (idx < 0)
            {
                Errors.IndexIsIncorrect();
                return;
            }

            if (idx >= Length)
            {
                AddLast(values);
            }
            else if (idx == 0)
            {
                AddFirst(values);
            }
            else
            {
                Node tmpNode = Head;
                for (int counter = 1; counter < idx; counter++)
                {
                    tmpNode = tmpNode.Next;
                }
                arrayValue.Tail.Next = tmpNode.Next;
                tmpNode.Next = arrayValue.Head;
                Length += arrayValue.Length;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Length];
            Node node = Head;
            int i = 0;
            while (node != null && i < Length)
            {
                array[i++] = node.Value;
                node = node.Next;
            }
            return array;
        }

        public int GetSize()
        {
            return Length;
        }

        public void Set(int idx, int value)
        {
            Node tmp = Head;
            Node node = new Node(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else if (idx > Length - 1)
            {
                Tail.Next = node;
                Tail = node;
                Length++;
            }
            else if (idx == 0)
            {
                Head.Value = node.Value;
            }
            else
            {
                for (int counter = 1; counter < idx + 1; counter++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = node.Value;
            }
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                Errors.NullHead();
                return;
            }

            if (Length == 1)
            {
                Head = null;
                Tail = null;
                Length = 0;
            }
            else
            {
                Head = Head.Next;
                Length--;
            }
        }

        public void RemoveLast()
        {
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                Length = 0;
                return;
            }

            Node tmpNode = Head;
            while (tmpNode.Next.Next != null)
            {
                tmpNode = tmpNode.Next;
            }

            Tail = tmpNode;
            Length--;
        }

        public void RemoveAt(int idx)
        {
            Node tmpNode = Head;

            if (idx >= Length - 1)
            {
                RemoveLast();
            }
            else if (idx == 0)
            {
                RemoveFirst();
            }
            else
            {
                for (int counter = 1; counter < idx; counter++)
                {
                    tmpNode = tmpNode.Next;
                }

                tmpNode.Next = tmpNode.Next.Next;
                Length--;
            }
        }

        public void RemoveAll(int val)
        {
            Node tmpNode = Head;
            int count = 0;

            for (int index = 0; tmpNode.Next != null; index++)
            {

                if (tmpNode.Value == val)
                {
                    RemoveAt(index - count);
                    count++;
                }
                tmpNode = tmpNode.Next;
            }

            if (Tail.Value == val) //когда последний эелмент = val
            {
                RemoveLast();
            }
        }

        public bool Contains(int val)
        {
            Node tmpNode = Head;
            bool answer = false;

            for (int index = 0; tmpNode != null; index++)
            {
                if (tmpNode.Value == val)
                {
                    answer = true;
                    return answer;
                }
                tmpNode = tmpNode.Next;
            }

            return answer;
        }

        public int IndexOf(int val)
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }

            int index = -1;
            Node tmpNode = Head;

            for (int i = 0; tmpNode != null; i++)
            {
                if (tmpNode.Value == val)
                {
                    index = i;
                    return index;
                }
                tmpNode = tmpNode.Next;
            }

            return index;
        }

        public int GetFirst()
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }

            int first = Head.Value;
            return first;
        }

        public int GetLast()
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }

            int last = Tail.Value;
            return last;
        }

        public int Get(int idx)
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }
            else if (idx > Length - 1)
            {
                Errors.IndexIsIncorrect();
                return -1;
            }

            int value;

            if (idx == 0)
            {
                value = GetFirst();
            }
            else if (idx == Length - 1)
            {
                value = GetLast();
            }
            else
            {
                Node tmpNode = Head;
                for (int counter = 1; counter < idx; counter++)
                {
                    tmpNode = tmpNode.Next;
                }

                value = tmpNode.Next.Value;
            }

            return value;
        }

        public void Reverse()
        {
            Node preHead = Head;
            Node tmpNode;

            while (preHead.Next != null)
            {
                tmpNode = preHead.Next;
                preHead.Next = preHead.Next.Next;
                tmpNode.Next = Head;
                Head = tmpNode;
            }

            Tail = preHead;
        }

        public int IndexOfMax()
        {
            int maxNumber = Head.Value;
            int index = 0;
            Node tmpNode = Head;

            for (int i = 0; i < Length; i++)
            {
                if (tmpNode.Value > maxNumber)
                {
                    maxNumber = tmpNode.Value;
                    index = i;
                }
                tmpNode = tmpNode.Next;
            }

            return index;
        }

        public int IndexOfMin()
        {
            int minNumber = Head.Value;
            int index = 0;
            Node tmpNode = Head;

            for (int i = 0; i < Length; i++)
            {
                if (tmpNode.Value < minNumber)
                {
                    minNumber = tmpNode.Value;
                    index = i;
                }
                tmpNode = tmpNode.Next;
            }

            return index;
        }

        public int Max()
        {
            int maxNumber = Head.Value;
            Node tmpNode = Head;

            for (int i = 0; i < Length; i++)
            {
                if (tmpNode.Value > maxNumber)
                {
                    maxNumber = tmpNode.Value;
                }
                tmpNode = tmpNode.Next;
            }

            return maxNumber;
        }

        public int Min()
        {
            int minNumber = Head.Value;
            Node tmpNode = Head;

            for (int i = 0; i < Length; i++)
            {
                if (tmpNode.Value < minNumber)
                {
                    minNumber = tmpNode.Value;
                }
                tmpNode = tmpNode.Next;
            }

            return minNumber;
        }

        public void Sort()
        {
            Head = MergeSort(Head);
            while (Tail.Next != null)
            {
                Tail = Tail.Next;
            }
        }

        public void SortDesc()
        {
            Head = MergeDescSort(Head);
            while (Tail.Next != null)
            {
                Tail = Tail.Next;
            }
        }

        private Node SortedMerge(Node a, Node b)
        {
            Node result = null;

            if (a == null)
            {
                Tail = b;
                return b;
            }

            if (b == null)
            {
                Tail = a;
                return a;
            }

            if (a.Value <= b.Value)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }
            return result;
        }

        private Node SortedDescMerge(Node a, Node b)
        {
            Node result = null;
            if (a == null)
            {
                Tail = b;
                return b;
            }

            if (b == null)
            {
                Tail = a;
                return a;
            }

            if (a.Value >= b.Value)
            {
                result = a;
                result.Next = SortedDescMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedDescMerge(a, b.Next);
            }
            return result;
        }

        private Node MergeSort(Node h)
        {
            if (h == null || h.Next == null)
            {
                return h;
            }

            Node middle = GetMiddle(h);
            Node nextofmiddle = middle.Next;

            middle.Next = null;

            Node left = MergeSort(h);

            Node right = MergeSort(nextofmiddle);

            Node sortedlist = SortedMerge(left, right);
            return sortedlist;
        }

        private Node MergeDescSort(Node h)
        {
            if (h == null || h.Next == null)
            {
                return h;
            }

            Node middle = GetMiddle(h);
            Node nextofmiddle = middle.Next;

            middle.Next = null;

            Node left = MergeDescSort(h);

            Node right = MergeDescSort(nextofmiddle);

            Node sortedlist = SortedDescMerge(left, right);
            return sortedlist;
        }

        private Node GetMiddle(Node h)
        {
            if (h == null)
                return h;
            Node fastptr = h.Next;
            Node slowptr = h;

            while (fastptr != null)
            {
                fastptr = fastptr.Next;
                if (fastptr != null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next;
                }
            }
            return slowptr;
        }


    }
}
