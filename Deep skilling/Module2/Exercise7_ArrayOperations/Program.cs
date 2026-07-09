using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };

        Console.WriteLine("Array Elements:");

        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\nSum = " + (10 + 20 + 30 + 40 + 50));
        Console.WriteLine("Length = " + arr.Length);
    }
}