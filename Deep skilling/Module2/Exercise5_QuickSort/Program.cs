using System;

class Program
{
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }

    static void Main()
    {
        int[] arr = { 10, 7, 8, 9, 1, 5 };

        Console.WriteLine("Before Sorting:");
        foreach (int x in arr)
            Console.Write(x + " ");

        QuickSort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nAfter Sorting:");
        foreach (int x in arr)
            Console.Write(x + " ");
    }
}