using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
        int left = 0;
        int right = arr.Length - 1;

        Console.Write("Enter number to search: ");
        int key = Convert.ToInt32(Console.ReadLine());

        bool found = false;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == key)
            {
                Console.WriteLine("Element found at index: " + mid);
                found = true;
                break;
            }
            else if (arr[mid] < key)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        if (!found)
        {
            Console.WriteLine("Element not found");
        }
    }
}