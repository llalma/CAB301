using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class quicksort
    {
        static public void Sort(int[] arr, int start, int end)
        {
            int pivot_indx = 0;

            if (start < end)
            {
                pivot_indx = Partition(arr, start, end);
                Sort(arr, start, pivot_indx - 1);
                Sort(arr, pivot_indx + 1, end);
            }
        }

        static private int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, end);
            return i + 1;
        }

        static private void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
