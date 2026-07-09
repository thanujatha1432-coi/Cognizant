using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);
        list.AddLast(40);

        Console.WriteLine("Linked List Elements:");

        foreach (int item in list)
        {
            Console.Write(item + " ");
        }
    }
}
