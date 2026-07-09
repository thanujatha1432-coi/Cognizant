using System;

class Program
{
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int a = 0, b = 0, k = left;

        while (a < n1 && b < n2)
        {
            if (L[a] <= R[b])
                arr[k++] = L[a++];
            else
                arr[k++] = R[b++];
        }

        while (a < n1)
            arr[k++] = L[a++];

        while (b < n2)
            arr[k++] = R[b++];
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Main()
    {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine("Before Sorting:");
        foreach (int x in arr)
            Console.Write(x + " ");

        MergeSort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nAfter Sorting:");
        foreach (int x in arr)
            Console.Write(x + " ");
    }
}
