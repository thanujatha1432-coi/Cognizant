using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };

        Console.Write("Enter number to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        int position = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
            {
                position = i;
                break;
            }
        }

        if (position != -1)
            Console.WriteLine("Element found at index: " + position);
        else
            Console.WriteLine("Element not found");
    }
}