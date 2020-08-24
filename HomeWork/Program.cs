using System;
using ArrayListAllMethods;
using LinkedListProject;

namespace HomeWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();            
            Print p = new Print();

            ll.AddFirst(4);
            ll.AddLast(8);
            ll.AddLast(2);
            ll.AddLast(10);
            //ll.AddLast(1);
            ll.AddFirst(85);
            int[] array = ll.ToArray();
            p.PrintOneDimArray(array);
            Console.WriteLine("");

            ll.SortDesc();
            array = ll.ToArray();
            p.PrintOneDimArray(array);
            Console.WriteLine("");

            ll.AddLast(0);
            array = ll.ToArray();
            p.PrintOneDimArray(array);
            Console.WriteLine("");

            //ll.SortDesc();
            //array = ll.ToArray();
            //p.PrintOneDimArray(array);
            //Console.WriteLine("");

        }

    }
}
